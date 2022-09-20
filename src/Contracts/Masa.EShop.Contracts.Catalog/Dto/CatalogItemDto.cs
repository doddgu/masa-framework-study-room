namespace Masa.EShop.Contracts.Catalog.Dto;

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
}
