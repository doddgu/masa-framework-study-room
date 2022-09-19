using Masa.Contrib.Data.UoW.EFCore;
using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;

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
    //.AddFluentValidationAutoValidation()
    //.AddFluentValidationClientsideAdapters()
    //.AddValidatorsFromAssembly("验证类所在程序集")
    .AddEventBus(builder =>
    {
        builder.UseMiddleware(typeof(ValidatorMiddleware<>));
    })
    .AddIntegrationEventBus(options =>
    {
        options.UseDapr();
        options.UseUoW<CatalogDbContext>(options => options.UseSqlite());
    })
    .AddServices(builder);

app.MigrateDbContext<CatalogDbContext>((context, services) =>
{
    var env = services.GetRequiredService<IWebHostEnvironment>();
    var options = services.GetRequiredService<IOptions<CatalogContextSeedOptions>>();
    var logger = services.GetService<ILogger<CatalogContextSeed>>()!;

    new CatalogContextSeed()
        .SeedAsync(context, env, options, logger)
        .Wait();
});

// Add swagger UI
app.UseSwagger().UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Masa EShop Service HTTP API v1");
});

app.Run();
