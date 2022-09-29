namespace Masa.EShop.Services.Catalog.Application.Catalogs;

public class ProductQueryHandler
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public ProductQueryHandler(ICatalogItemRepository catalogItemRepository)
        => _catalogItemRepository = catalogItemRepository;

    [EventHandler]
    public async Task ProductsHandleAsync(ProductsQuery query)
    {
        Expression<Func<CatalogItem, bool>> exp = item => true;
        exp = exp
            .And(query.TypeId > 0, item => item.CatalogTypeId == query.TypeId)
            .And(query.BrandId > 0, item => item.CatalogBrandId == query.BrandId);

        var queryable = _catalogItemRepository.Query(exp);

        var total = await queryable.LongCountAsync();

        var totalPages = (int)Math.Ceiling((double)total / query.PageSize);

        var result = await queryable
            .OrderBy(item => item.Name)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .OrderByDescending(ci => ci.Id)
            .ToListAsync();
        
        query.Result = new PaginatedResultDto<CatalogListItemDto>(total, totalPages, result.Map<List<CatalogListItemDto>>());
    }

    [EventHandler]
    public async Task ProductHandleAsync(ProductQuery query)
    {
        query.Result = await _catalogItemRepository.SingleAsync(query.ProductId);
    }
}

