using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Application.Extensions;
using Catalog.Application.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler(IAppDbContext dbContext) : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var pageNumber = query.PaginationRequest.PageNumber;
        var pageSize = query.PaginationRequest.PageSize;

        var productQuery = dbContext.Products.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.PaginationRequest.Search))
        {
            productQuery = productQuery.Where(p =>
                p.Name.Contains(query.PaginationRequest.Search) ||
                (p.Description != null && p.Description.Contains(query.PaginationRequest.Search))
            );
        }
        var totalCount = await productQuery.LongCountAsync(cancellationToken);

        var products = await productQuery
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync(cancellationToken);

        return new GetProductsResponse
        (
            new PaginatedResult<ProductDto>(
                pageNumber,
                pageSize,
                totalCount,
                products.MapToProductDto()
        ));
    }
}
