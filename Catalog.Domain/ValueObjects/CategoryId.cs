namespace Catalog.Domain.ValueObjects;

public record CategoryId
{
    public Guid? Value { get; }

    private CategoryId(Guid? value) => Value = value;

    public static CategoryId Of(Guid? value)
    {
        return new CategoryId(value);
    }
}
