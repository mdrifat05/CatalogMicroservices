using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Exceptions;

namespace Catalog.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IAppDbContext dbContext) : ICommandHandler<DeleteProductCommand, DeleteProdutResponse>
{
    public async Task<DeleteProdutResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([command.ProductId], cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.ProductId);
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProdutResponse(true);
    }
}
