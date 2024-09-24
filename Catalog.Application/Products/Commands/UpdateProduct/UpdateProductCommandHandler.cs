using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Application.Exceptions;
using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
namespace Catalog.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IAppDbContext dbContext) : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
{
    public async Task<UpdateProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([command.ProductDto.Id], cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.ProductDto.Id);
        }

        UpdateProductWithNewValue(product, command.ProductDto);
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProductResponse(true);
    }

    private static void UpdateProductWithNewValue(Product product, ProductDto productDto)
    {
        var productWeight = ProductWeight.Of(productDto.ProductWeightDto.Value, productDto.ProductWeightDto.Unit);
        var productPrice = ProductPrice.Of(productDto.ProductPriceDto.Amount, productDto.ProductPriceDto.Currency);

        product.Update(
           productDto.Name,
           productWeight,
           productPrice,
           productDto.ProductStatusDto,
           productDto.CategoryId,
           productDto.Description,
           productDto.ImageUrl
       );
    }
}
