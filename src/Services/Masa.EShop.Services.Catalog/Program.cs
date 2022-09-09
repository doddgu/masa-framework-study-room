var builder = WebApplication.CreateBuilder(args);

var app = builder.Services
    // used for swagger
    .AddEndpointsApiExplorer()
    // add swagger
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "MASA EShop - Catalog HTTP API",
            Version = "v1",
            Description = "The Catalog Service HTTP API",
        });
    })
    .AddServices(builder);

app.MapGet("/", () => "Hello World!");

// add swagger UI
app.UseSwagger().UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Masa EShop Service HTTP API v1");
});

app.Run();
