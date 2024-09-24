using Catalog.Domain.Enums;

namespace Catalog.Application.Dtos;

public record ProductPriceDto(decimal Amount, Currency Currency);
