namespace Masa.EShop.Services.Catalog.Domain.Repositories
{
    public interface ICatalogBrandRepository : IRepository<CatalogBrand>
    {
        IQueryable<CatalogBrand> GetAll();
    }
}
