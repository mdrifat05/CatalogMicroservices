using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;
using FluentValidation;

namespace Catalog.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(ProductDto ProductDto) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotNull().NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.ProductDto.Description).NotNull().NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.ProductDto.ProductPriceDto.Amount).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.ProductDto.ProductStatusDto).NotNull().NotEmpty().WithMessage("Status is required");
    }
}

