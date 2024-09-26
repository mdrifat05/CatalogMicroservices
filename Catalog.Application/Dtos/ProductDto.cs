using Catalog.Domain.Enums;

namespace Catalog.Application.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string? Description,
    string? ImageUrl,
    ProductWeightDto ProductWeightDto,
    ProductPriceDto ProductPriceDto,
    ProductStatus ProductStatusDto,
    Guid? CategoryId
    );
