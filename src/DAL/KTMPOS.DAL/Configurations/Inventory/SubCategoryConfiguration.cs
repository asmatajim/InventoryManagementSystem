using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.Inventory
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
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
            .WithMany(c => c.CreatedSubCategories)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.ModifiedByUser)
            .WithMany(c => c.ModifiedSubCategories)
            .HasForeignKey(c => c.ModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}