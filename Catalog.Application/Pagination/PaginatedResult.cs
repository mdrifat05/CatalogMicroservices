namespace Catalog.Application.Pagination;

public class PaginatedResult<TEntity>(int pageNumber, int pageSize, long count, IEnumerable<TEntity> data) where TEntity : class
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public long Count { get; set; } = count;
    public IEnumerable<TEntity> Data { get; set; } = data;
}
