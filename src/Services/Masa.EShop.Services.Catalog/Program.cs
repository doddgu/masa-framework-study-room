var builder = WebApplication.CreateBuilder(args);

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
    .AddMasaDbContext<CatalogDbContext>(builder => builder.UseSqlite())
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

app.Run();