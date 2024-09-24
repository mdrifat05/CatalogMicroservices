using BuildingBlocks.CQRS;
using FluentValidation;

namespace Catalog.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProdutResponse>;

public record DeleteProdutResponse(bool IsSuccess);


public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is required");
    }
}