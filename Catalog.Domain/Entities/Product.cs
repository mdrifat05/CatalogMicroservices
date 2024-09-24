using Catalog.Domain.Abstractions;
using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

public sealed class Product : Entity<ProductId>
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; } = default!;

    public string? ImageUrl { get; set; } = default!;

    public ProductWeight Weight { get; set; } = default!;

    public ProductPrice Price { get; set; } = default!;

    public ProductStatus Status { get; set; } = ProductStatus.InStock;

    //navigation properties
    public Category? Category { get; set; } = default!;

    public CategoryId? CategoryId { get; set; } = default!;

    public static Product Create(ProductId id, string name, ProductWeight productWeight, ProductPrice productPrice, ProductStatus productStatus, string? description = null, string? imageUrl = null, CategoryId? categoryId = null)
    {
        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            ImageUrl = imageUrl,
            Weight = productWeight,
            Price = productPrice,
            Status = productStatus,
            CategoryId = categoryId,
        };
        return product;
    }
    public void Update(string name, ProductWeight productWeight, ProductPrice productPrice, ProductStatus productStatus, CategoryId? categoryId, string? description = null, string? imageUrl = null)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Weight = productWeight;
        Price = productPrice;
        Status = productStatus;
        CategoryId = categoryId;
    }
}
