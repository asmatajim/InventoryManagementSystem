using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.Inventory
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder
            .HasIndex(c => c.Name)
            .IsUnique();

            builder
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(c => c.CreatedByUser)
            .WithMany(c => c.CreatedCategories)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.ModifiedByUser)
            .WithMany(c => c.ModifiedCategories)
            .HasForeignKey(c => c.ModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}