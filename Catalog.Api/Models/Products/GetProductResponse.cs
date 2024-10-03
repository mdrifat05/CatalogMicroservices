using Catalog.Application.Dtos;
using Catalog.Application.Pagination;

namespace Catalog.Api.Models.Products;

public sealed record GetProductResponse(PaginatedResult<ProductDto> Product);