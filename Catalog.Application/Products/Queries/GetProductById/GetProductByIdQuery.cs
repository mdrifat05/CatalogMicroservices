using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;

namespace Catalog.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdQueryResponse>;

public record GetProductByIdQueryResponse(ProductDto Product);