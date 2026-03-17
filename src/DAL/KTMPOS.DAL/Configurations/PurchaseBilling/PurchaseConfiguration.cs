using KTMPOS.DAL.Entities.PurchaseBilling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.PurchaseBilling
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder
            .ToTable("Purchases", x => x.HasCheckConstraint("CK_GrandTotal", "[GrandTotal] > 0"));

            builder
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(c => c.CreatedByUser)
            .WithMany(c => c.CreatedPurchases)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Supplier)
            .WithMany(c => c.Purchases)
            .HasForeignKey(c => c.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}