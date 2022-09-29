namespace Masa.EShop.Services.Catalog.Application.CatalogBrands.Queries;

public record CatalogBrandsQuery : Query<IList<CatalogBrandDto>>
{
    public override IList<CatalogBrandDto> Result { get; set; } = new List<CatalogBrandDto>();
}

