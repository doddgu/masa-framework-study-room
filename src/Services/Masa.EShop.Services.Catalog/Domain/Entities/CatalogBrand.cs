namespace Masa.EShop.Services.Catalog.Domain.Entities;

public class CatalogBrand : FullAggregateRoot<int, int>
{
    public string Brand { get; set; } = null!;
}
