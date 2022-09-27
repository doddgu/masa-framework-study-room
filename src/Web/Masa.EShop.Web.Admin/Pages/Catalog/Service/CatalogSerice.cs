using Masa.BuildingBlocks.Service.Caller;

namespace Masa.EShop.Web.Admin.Pages.Catalog.Service;

public class CatalogSericeCaller : IScopedDependency
{
    private ICaller _caller = default!;

    public CatalogSericeCaller(ICaller caller)
    {
        _caller = caller;
    }

    public async Task<CatalogItemDto> GetAsync(int id)
    {
        return (await _caller.GetAsync<CatalogItemDto>($"/api/v1/catalogs/{id}"))!;
    }

    public async Task<List<CatalogTypeDto>> GetTypesAsync()
    {
        return (await _caller.GetAsync<List<CatalogTypeDto>>("/api/v1/catalogs/Types"))!;
    }

    public async Task<List<CatalogBrandDto>> GetBrandsAsync()
    {
        return (await _caller.GetAsync<List<CatalogBrandDto>>("/api/v1/catalogs/Brands"))!;
    }

    public async Task<PaginatedResultDto<CatalogListItemDto>> GetItemsAsync(int page, int pageSize, int typeId, int brandId)
    {
        return (await _caller.GetAsync<PaginatedResultDto<CatalogListItemDto>>("/api/v1/catalogs/Items", new
        {
            TypeId = typeId,
            BrandId = brandId,
            Page = page,
            PageSize = pageSize
        }))!;
    }

    public async Task AddProductAsync(AddProductViewModel vm)
    {
        _ = await _caller.PostAsync("/api/v1/catalogs/product", vm);
    }
}