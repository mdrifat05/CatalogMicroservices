using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;
using FluentValidation;

namespace Catalog.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(ProductDto ProductDto) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.ProductDto.ProductPriceDto.Amount).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

