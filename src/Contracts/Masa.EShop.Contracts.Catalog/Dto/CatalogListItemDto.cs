namespace Masa.EShop.Contracts.Catalog.Dto;

public class CatalogListItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = "";

    public int CatalogTypeId { get; set; }

    public int CatalogBrandId { get; set; }

    public int AvailableStock { get; set; }
}