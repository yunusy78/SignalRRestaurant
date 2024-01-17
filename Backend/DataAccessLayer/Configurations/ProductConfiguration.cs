using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.ImageUrl).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.CategoryId).IsRequired();
        builder.HasOne(x=> x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
        builder.ToTable("Products");
    }
}