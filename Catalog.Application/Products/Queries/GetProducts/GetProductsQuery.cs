using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;
using Catalog.Application.Pagination;

namespace Catalog.Application.Products.Queries.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest) : IQuery<GetProductsResponse>;

public record GetProductsResponse(PaginatedResult<ProductDto> Product);
