namespace Masa.EShop.Services.Catalog.Service;

public class CatalogService : ServiceBase
{
    //public CatalogService(IServiceCollection services)
    //    : base(services)
    //{
    //    App.MapGet("/api/v1/catalog/{id}", GetAsync);
    //    App.MapGet("/api/v1/catalog/items", GetItemsAsync);
    //    App.MapGet("/api/v1/catalog/brands", GetBrandsAsync);
    //    App.MapGet("/api/v1/catalog/types", GetTypesAsync);
    //    App.MapPost("/api/v1/catalog/product", CreateProductAsync);
    //    App.MapPost("/api/v1/catalog/type", CreateTypeAsync);
    //    App.MapDelete("/api/v1/catalog/product/{id}", DeleteProductAsync);
    //}

    #region Query

    public async Task<IResult> GetAsync([FromServices] IEventBus eventBus, int id)
    {
        var query = new ProductQuery() { ProductId = id };
        await eventBus.PublishAsync(query);
        return Results.Ok(query.Result.Map<CatalogItemDto>());
    }

    public async Task<IResult> GetItemsAsync([FromServices] IEventBus eventBus,
        [FromQuery] int typeId = 0,
        [FromQuery] int brandId = 0,
        [FromQuery] int pageIndex = 0,
        [FromQuery] int pageSize = 10)
    {
        var query = new ProductsQuery()
        {
            TypeId = typeId,
            BrandId = brandId,
            PageIndex = pageIndex,
            PageSize = pageSize
        };
        await eventBus.PublishAsync(query);
        return Results.Ok(query.Result);
    }

    public async Task<IResult> GetBrandsAsync([FromServices] IEventBus eventBus)
    {
        var query = new CatalogBrandsQuery();
        await eventBus.PublishAsync(query);
        return Results.Ok(query.Result);
    }

    public async Task<IResult> GetTypesAsync([FromServices] IEventBus eventBus)
    {
        var query = new CatalogTypesQuery();
        await eventBus.PublishAsync(query);
        return Results.Ok(query.Result);
    }

    #endregion

    #region Command

    public async Task<IResult> CreateProductAsync(
        CreateProductCommand command,
        [FromServices] IEventBus eventBus)
    {
        await eventBus.PublishAsync(command);
        return Results.Accepted();
    }

    public async Task<IResult> CreateTypeAsync(
        CreateCatalogTypeCommand command,
        [FromServices] IEventBus eventBus)
    {
        await eventBus.PublishAsync(command);
        return Results.Accepted();
    }

    public async Task<IResult> DeleteProductAsync(HttpContext context, int id, [FromServices] IEventBus eventBus)
    {
        await eventBus.PublishAsync(new DeleteProductCommand() { ProductId = id });

        return Results.Accepted();
    }

    #endregion
}