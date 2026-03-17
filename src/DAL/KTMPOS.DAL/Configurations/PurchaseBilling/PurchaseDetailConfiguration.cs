using KTMPOS.DAL.Entities.PurchaseBilling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.PurchaseBilling
{
    public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
        {
            builder
            .ToTable("PurchaseDetails", x => x.HasCheckConstraint("CK_UnitPrice", "[UnitPrice] > 0"));

            builder
            .ToTable("PurchaseDetails", x => x.HasCheckConstraint("CK_Qty", "[Qty] > 0"));

            builder
            .Property(u => u.SubTotal)
            .HasComputedColumnSql("[Qty] * [UnitPrice]", stored: true);

            builder
            .HasOne(c => c.Purchase)
            .WithMany(c => c.PurchaseDetails)
            .HasForeignKey(c => c.PurchaseId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Product)
            .WithMany(c => c.PurchaseDetails)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}