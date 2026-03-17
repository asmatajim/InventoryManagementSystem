using KTMPOS.DAL.Entities.POS;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.POS
{
    public class SalesDetailConfiguration : IEntityTypeConfiguration<SalesDetail>
    {
        public void Configure(EntityTypeBuilder<SalesDetail> builder)
        {
            builder
            .ToTable("SalesDetails", x => x.HasCheckConstraint("CK_SalesDetail_UnitPrice", "[UnitPrice] > 0"));

            builder
            .ToTable("SalesDetails", x => x.HasCheckConstraint("CK_SalesDetail_Qty", "[Qty] > 0"));

            builder
            .Property(u => u.SubTotal)
            .HasComputedColumnSql("[Qty] * [UnitPrice]", stored: true);

            builder
            .HasOne(c => c.Sales)
            .WithMany(c => c.SalesDetails)
            .HasForeignKey(c => c.SalesId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Product)
            .WithMany(c => c.SalesDetails)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}