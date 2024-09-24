using Catalog.Domain.Enums;

namespace Catalog.Domain.ValueObjects;

public record ProductPrice
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    protected ProductPrice() { }
    private ProductPrice(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static ProductPrice Of(decimal amount, Currency currency)
    {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        ArgumentNullException.ThrowIfNull(currency);

        return new ProductPrice(amount, currency);
    }
}

