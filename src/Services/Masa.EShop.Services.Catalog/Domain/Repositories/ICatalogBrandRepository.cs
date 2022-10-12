namespace Masa.EShop.Services.Catalog.Domain.Repositories
{
    public interface ICatalogBrandRepository : IScopedDependency
    {
        IQueryable<CatalogBrand> GetAll();
    }
}
