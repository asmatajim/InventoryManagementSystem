using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Reflection.Emit;

namespace KTMPOS.DAL.Configurations.Inventory
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .ToTable("Products", x => x.HasCheckConstraint("CK_PurchasePrice", "[PurchasePrice] > 0"));

            builder
            .ToTable("Products", x => x.HasCheckConstraint("CK_SellingPrice", "[SellingPrice] > 0 AND ([SellingPrice] >= (([PurchasePrice] + [PurchasePrice] * 0.05)) AND [SellingPrice] <= ([PurchasePrice] + ([PurchasePrice] * 0.45)))"));

            builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

            builder
            .HasIndex(x => x.Name)
            .IsUnique();

            builder
            .Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(x => x.CreatedByUser)
            .WithMany(x => x.CreatedProducts)
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.ModifiedByUser)
            .WithMany(x => x.ModifiedProducts)
            .HasForeignKey(x => x.ModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.SubCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}