namespace Masa.EShop.Web.Admin.Pages.Catalog.ViewModel;

public class AddProductViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CatalogBrandId { get; set; }

    public int CatalogTypeId { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = "default.png";
}