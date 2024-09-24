using Catalog.Domain.Enums;

namespace Catalog.Domain.ValueObjects;

public record ProductWeight
{
    public decimal Value { get; set; }

    public WeightUnit Unit { get; set; }

    protected ProductWeight() { }

    private ProductWeight(decimal value, WeightUnit unit)
    {
        Value = value;
        Unit = unit;
    }
    public static ProductWeight Of(decimal value, WeightUnit unit)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
        ArgumentNullException.ThrowIfNull(unit);
        return new ProductWeight(value, unit);
    }
}
