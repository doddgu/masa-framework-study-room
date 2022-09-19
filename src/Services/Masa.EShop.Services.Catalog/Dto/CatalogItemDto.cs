namespace Masa.EShop.Services.Catalog.Dto;

public class CatalogItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = default!;

    public string Type { get; set; } = default!;

    public string Brand { get; set; } = default!;

    public int AvailableStock { get; set; }

    public static CatalogItemDto FromOrderItem(CatalogItem catalogItem)
    {
        return new CatalogItemDto
        {
            Id = catalogItem.Id,
            Name = catalogItem.Name,
            Description = catalogItem.Description ?? "",
            Price = catalogItem.Price,
            PictureFileName = catalogItem.PictureFileName,
            Type = catalogItem.CatalogType.Type,
            Brand = catalogItem.CatalogBrand.Brand,
            AvailableStock = catalogItem.AvailableStock
        };
    }
}
