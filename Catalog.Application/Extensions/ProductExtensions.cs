using Catalog.Application.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Extensions;

public static class ProductExtensions
{
    public static IEnumerable<ProductDto> MapToProductDto(this IEnumerable<Product> products)
    {
        return products.Select(product => new ProductDto(
             Id: product.Id.Value,
             Name: product.Name,
             Description: product.Description,
             ImageUrl: product.ImageUrl,
             ProductWeightDto: new ProductWeightDto(product.Weight.Value, product.Weight.Unit),
             ProductPriceDto: new ProductPriceDto(product.Price.Amount, product.Price.Currency),
             ProductStatusDto: product.Status,
             CategoryId: product.CategoryId?.Value
        ));
    }

    public static ProductDto MapToProductDto(this Product product)
    {
        return new ProductDto(
             Id: product.Id.Value,
             Name: product.Name,
             Description: product.Description,
             ImageUrl: product.ImageUrl,
             ProductWeightDto: new ProductWeightDto(product.Weight.Value, product.Weight.Unit),
             ProductPriceDto: new ProductPriceDto(product.Price.Amount, product.Price.Currency),
             ProductStatusDto: product.Status,
             CategoryId: product.CategoryId?.Value
        );
    }
}
