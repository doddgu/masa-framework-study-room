namespace Masa.EShop.Services.Catalog.Application.Catalogs.Queries;

public record ProductsQuery : Query<PaginatedResultDto<CatalogListItemDto>>
{
    public int PageSize { get; set; } = default!;

    public int Page { get; set; } = default!;

    public int TypeId { get; set; } = default!;

    public int BrandId { get; set; } = default!;

    public override PaginatedResultDto<CatalogListItemDto> Result { get; set; } = default!;
}