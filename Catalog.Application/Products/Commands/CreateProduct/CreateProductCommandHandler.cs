using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IAppDbContext dbContext) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = CreateNewProduct(command.ProductDto);

        dbContext.Products.Add(product);

        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id.Value);
    }

    private static Product CreateNewProduct(ProductDto productDto)
    {
        var productWeight = ProductWeight.Of(productDto.ProductWeightDto.Value, productDto.ProductWeightDto.Unit);
        var productPrice = ProductPrice.Of(productDto.ProductPriceDto.Amount, productDto.ProductPriceDto.Currency);

        var newProduct = Product.Create(
            ProductId.Of(Guid.NewGuid()),
            productDto.Name,
            productWeight,
            productPrice,
            productDto.ProductStatusDto,
            productDto.Description,
            productDto.ImageUrl,
            CategoryId.Of(productDto.CategoryId)
            );

        return newProduct;
    }
}