using KTMPOS.DAL.Entities.PurchaseBilling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.PurchaseBilling
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

            builder
            .Property(x => x.ContactPerson)
            .HasMaxLength(100);

            builder
            .Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

            builder
            .HasIndex(x => x.PhoneNumber)
            .IsUnique();

            builder
            .Property(x => x.EmailAddress)
            .HasMaxLength(150);

            builder
            .HasIndex(x => x.EmailAddress)
            .IsUnique();

            builder
            .Property(x => x.Address)
            .HasMaxLength(500);

            builder
            .Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(x => x.CreatedByUser)
            .WithMany(x => x.CreatedSuppliers)
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(x => x.ModifiedByUser)
            .WithMany(x => x.ModifiedSuppliers)
            .HasForeignKey(x => x.ModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}