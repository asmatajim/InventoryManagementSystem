using KTMPOS.DAL.Entities.POS;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.POS
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder
            .ToTable("Sales", x => x.HasCheckConstraint("CK_Sales_GrandTotal", "[GrandTotal] > 0"));

            builder
            .Property(u => u.NetTotal)
            .HasComputedColumnSql("[GrandTotal] - [DiscountAmount]", stored: true);

            builder
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(c => c.CreatedByUser)
            .WithMany(c => c.CreatedSales)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}