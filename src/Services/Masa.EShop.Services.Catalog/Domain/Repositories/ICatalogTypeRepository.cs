namespace Masa.EShop.Services.Catalog.Domain.Repositories;

public interface ICatalogTypeRepository : IScopedDependency
{
    Task AddAsync(CatalogType catalogType);

    Task DeleteAsync(int catalogTypeId);

    IQueryable<CatalogType> GetAll();
}
