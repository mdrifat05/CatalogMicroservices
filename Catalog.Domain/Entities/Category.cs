using Catalog.Domain.Abstractions;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

public sealed class Category : Entity<CategoryId>
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public ICollection<Product>? Products { get; set; }
}