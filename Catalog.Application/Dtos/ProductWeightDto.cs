using Catalog.Domain.Enums;

namespace Catalog.Application.Dtos;

public record ProductWeightDto(decimal Value, WeightUnit Unit);
