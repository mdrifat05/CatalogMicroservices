using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Exceptions;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IAppDbContext dbContext) : ICommandHandler<DeleteProductCommand, DeleteProdutResult>
{
    public async Task<DeleteProdutResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([ProductId.Of(command.ProductId)], cancellationToken) ?? throw new ProductNotFoundException(command.ProductId);

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProdutResult(true);
    }
}
