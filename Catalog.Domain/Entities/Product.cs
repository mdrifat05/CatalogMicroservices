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

    public static Product Create(ProductId id, string name, ProductWeight weight, ProductPrice price, ProductStatus status, string? description = null, string? imageUrl = null, CategoryId? categoryId = null)
    {
        var product = new Product { Id = id };
        product.SetProductDetails(name, weight, price, status, description, imageUrl, categoryId);
        //publish domain event
        return product;
    }
    public void Update(string name, ProductWeight weight, ProductPrice price, ProductStatus status, CategoryId? categoryId, string? description = null, string? imageUrl = null)
    {
        SetProductDetails(name, weight, price, status, description, imageUrl, categoryId);
        //publish domain event
    }

    private void SetProductDetails(string name, ProductWeight weight, ProductPrice price, ProductStatus status, string? description, string? imageUrl, CategoryId? categoryId)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Weight = weight;
        Price = price;
        Status = status;
        CategoryId = categoryId;
    }
}
