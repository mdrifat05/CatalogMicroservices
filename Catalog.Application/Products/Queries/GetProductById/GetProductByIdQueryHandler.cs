using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Exceptions;
using Catalog.Application.Extensions;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(IAppDbContext dbContext) : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
{
    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([ProductId.Of(query.ProductId)], cancellationToken);

        return product is null
            ? throw new ProductNotFoundException(query.ProductId)
            : new GetProductByIdQueryResponse(product.MapToProductDto());
    }
}
