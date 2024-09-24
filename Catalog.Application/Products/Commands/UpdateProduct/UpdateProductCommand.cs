using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;
using FluentValidation;

namespace Catalog.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(ProductDto ProductDto) : ICommand<UpdateProductResponse>;
public record UpdateProductResponse(bool isSuccess);

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.ProductDto.Id).NotEmpty().WithMessage("Product id should be provided");
        RuleFor(x => x.ProductDto.Name).NotEmpty().WithMessage("Product name should be provided");
        RuleFor(x => x.ProductDto.CategoryId).NotNull().WithMessage("Product CategoryId should be provided");
    }
}