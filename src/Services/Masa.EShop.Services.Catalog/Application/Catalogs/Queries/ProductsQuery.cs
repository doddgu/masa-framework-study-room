namespace Masa.EShop.Services.Catalog.Application.Catalogs.Queries;

public record ProductsQuery : Query<PaginatedResultDto<CatalogItem>>
{
    public int PageSize { get; set; } = default!;

    public int PageIndex { get; set; } = default!;

    public int TypeId { get; set; } = default!;

    public int BrandId { get; set; } = default!;

    public override PaginatedResultDto<CatalogItem> Result { get; set; } = default!;
}