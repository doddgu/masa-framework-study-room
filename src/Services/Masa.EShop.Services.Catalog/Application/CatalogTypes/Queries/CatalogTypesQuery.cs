namespace Masa.EShop.Services.Catalog.Application.CatalogTypes.Queries;

public record CatalogTypesQuery : Query<IList<CatalogTypeDto>>
{
    public override IList<CatalogTypeDto> Result { get; set; } = new List<CatalogTypeDto>();

}
