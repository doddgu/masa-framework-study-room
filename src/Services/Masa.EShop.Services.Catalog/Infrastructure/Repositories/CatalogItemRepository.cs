using Masa.BuildingBlocks.Caching;

namespace Masa.EShop.Services.Catalog.Infrastructure.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly CatalogDbContext _context;
    private readonly IMultilevelCacheClient _cacheClient;

    public CatalogItemRepository(CatalogDbContext context, IMultilevelCacheClient cacheClient)
    {
        _context = context;
        _cacheClient = cacheClient;
    }

    public async Task AddAsync(CatalogItem catalogItem)
    {
        await _context.CatalogItems.AddAsync(catalogItem);
        await _context.SaveChangesAsync();

        await _cacheClient.GetOrSetAsync(catalogItem.Id.ToString(), () => new CacheEntry<CatalogItem>(catalogItem));
    }

    public async Task DeleteAsync(int catalogId)
    {
        var catalogItem = await _context.Set<CatalogItem>().FirstOrDefaultAsync(catalogType => catalogType.Id == catalogId) ?? throw new ArgumentNullException("CatalogItem does not exist");
        _context.CatalogItems.Remove(catalogItem);
        await _context.SaveChangesAsync();

        await _cacheClient.RemoveAsync<CatalogItem>(catalogId.ToString());
    }

    public IQueryable<CatalogItem> Query(Expression<Func<CatalogItem, bool>> predicate)
    {
        return _context.Set<CatalogItem>().Where(predicate);
    }

    public async Task<CatalogItem> SingleAsync(int productionId)
    {
        return await _context.CatalogItems
            .Include(catalogItem => catalogItem.CatalogType)
            .Include(catalogItem => catalogItem.CatalogBrand)
            .AsSplitQuery()
            .SingleAsync(catalogItem => catalogItem.Id == productionId);
    }
}
