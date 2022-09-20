namespace Masa.EShop.Web.Admin.Pages.Catalog.ViewModel;

public class CatalogListItemViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = default!;

    public int CatalogTypeId { get; set; }

    public string CatalogTypeName { get; set; } = default!;

    public int CatalogBrandId { get; set; }

    public string CatalogBrandName { get; set; } = default!;

    public int AvailableStock { get; set; }
}