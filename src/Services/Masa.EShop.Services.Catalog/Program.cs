using Masa.BuildingBlocks.Caching;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG

builder.Services.AddDaprStarter();

#endif

var app = builder.Services
    // Used for swagger
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "MASA EShop - Catalog HTTP API",
            Version = "v1",
            Description = "The Catalog Service HTTP API",
        });
    })
    .AddAutoInject()
    .AddMasaDbContext<CatalogDbContext>(builder =>
    {
        builder.UseSqlite();
        builder.UseFilter();
    })
    .AddMultilevelCache(distributedCacheOptions =>
    {
        distributedCacheOptions.UseStackExchangeRedisCache();
    })
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
    .AddEventBus(builder =>
    {
        builder.UseMiddleware(typeof(ValidatorMiddleware<>));
    })
    //todo: Add local message service
    .AddIntegrationEventBus(options =>
    {
        options.UseDapr();
        options.UseUoW<CatalogDbContext>(options => options.UseSqlite());
    })
    .AddMapster()
    .AddServices(builder);

app.UseMasaExceptionHandler();

// Add swagger UI
app.UseSwagger().UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Masa EShop Service HTTP API v1");
});

app.MigrateDbContext<CatalogDbContext>((context, services) =>
{
    var env = services.GetRequiredService<IWebHostEnvironment>();
    var options = services.GetRequiredService<IOptions<CatalogContextSeedOptions>>();
    var logger = services.GetService<ILogger<CatalogContextSeed>>()!;

    new CatalogContextSeed()
        .SeedAsync(context, env, options, logger)
        .Wait();
});

// Init caching
var serviceProvider = app.Services.CreateScope().ServiceProvider;
var repo = serviceProvider.GetRequiredService<ICatalogItemRepository>();
var catalogs = repo.Query(ci => true);
var cacheClient = serviceProvider.GetRequiredService<IMultilevelCacheClient>();
await cacheClient.SetListAsync(catalogs.ToDictionary(catalog => catalog.Id.ToString(), catalog => (CatalogItem?)catalog));

app.Run();
