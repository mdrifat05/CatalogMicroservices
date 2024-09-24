using Catalog.Domain.Entities;
using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(productId => productId.Value, dbId => ProductId.Of(dbId));
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.ComplexProperty(p => p.Weight, weightbuilder =>
        {
            weightbuilder.Property(p => p.Value).IsRequired();
            weightbuilder.Property(p => p.Unit).IsRequired();
        });
        builder.ComplexProperty(p => p.Price, pricebuilder =>
        {
            pricebuilder.Property(p => p.Currency).IsRequired();
            pricebuilder.Property(p => p.Amount).IsRequired();
        });
        builder.Property(p => p.Status).HasConversion(s => s.ToString(), dbStatus => (ProductStatus)Enum.Parse(typeof(ProductStatus), dbStatus));
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        //builder.Property<uint>("Version").IsRowVersion(); 
    }
}
