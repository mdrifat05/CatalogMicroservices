﻿using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects;

public record CategoryId
{
    public Guid Value { get; }

    private CategoryId(Guid value) => Value = value;

    public static CategoryId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("Category Id cannot be empty.");
        }

        return new CategoryId(value);
    }
}
