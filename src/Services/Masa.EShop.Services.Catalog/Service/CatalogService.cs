namespace Masa.EShop.Services.Catalog.Service;

public class CatalogService : ServiceBase
{
    //public CatalogService()
    //{
    //    App.MapGet("/api/v1/catalog/{id:int?}", GetAsync);
    //    App.MapGet("/api/v1/catalog/items", GetItemsAsync);
    //    App.MapGet("/api/v1/catalog/brands", GetCatalogBrandsAsync);
    //    App.MapGet("/api/v1/catalog/types", GetCatalogTypesAsync);
    //    App.MapPost("/api/v1/catalog/createproduct", CreateProductAsync);
    //    App.MapPost("/api/v1/catalog/createcatalogtype", CreateCatalogTypeAsync);
    //}

    #region Query

    public async Task<IResult> GetAsync([FromServices] IEventBus eventBus, int id)
    {
        var query = new ProductQuery() { ProductId = id };
        await eventBus.PublishAsync(query);
        return Results.Ok(CatalogItemDto.FromOrderItem(query.Result));
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

    public async Task<IResult> GetCatalogBrandsAsync([FromServices] IEventBus eventBus)
    {
        var query = new CatalogBrandsQuery();
        await eventBus.PublishAsync(query);
        return Results.Ok(query.Result);
    }

    public async Task<IResult> GetCatalogTypesAsync([FromServices] IEventBus eventBus)
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

    public async Task<IResult> CreateCatalogTypeAsync(
        CreateCatalogTypeCommand command,
        [FromServices] IEventBus eventBus)
    {
        await eventBus.PublishAsync(command);
        return Results.Accepted();
    }

    public Task<ActionResult> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    #endregion
}