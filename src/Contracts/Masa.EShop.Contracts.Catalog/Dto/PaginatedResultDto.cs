namespace Masa.EShop.Contracts.Catalog.Dto;

public class PaginatedResultDto<T>
        where T : class
{
    public long Total { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<T> Result { get; set; }

    public PaginatedResultDto(long total, int totalPages, IEnumerable<T> result)
    {
        Total = total;
        TotalPages = totalPages;
        Result = result;
    }
}