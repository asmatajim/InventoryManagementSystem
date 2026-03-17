using KTMPOS.DAL.Entities.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.Users
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder
            .HasIndex(u => u.Name)
            .IsUnique();

            builder
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(30);

            builder
            .Property(u => u.NormalizedName)
            .IsRequired()
            .HasMaxLength(30);

            builder
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .ToTable(b => b.HasCheckConstraint("CK_AspNetRoles_NormalizedName", "[NormalizedName]=UPPER(Name)"));

            builder.HasData(GetRoles());
        }

        private List<AppRole> GetRoles()
        {
            var roles = new List<AppRole>
            {
                new AppRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "99d2c935-e3a1-4c8f-a79f-837cfb3e7b3a",
                },
                new AppRole
                {
                    Id = 2,
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "d688d229-b411-46d7-9eaf-147900d7289b",
                },
                new AppRole
                {
                    Id = 3,
                    Name = "Inventory",
                    NormalizedName = "INVENTORY",
                    ConcurrencyStamp = "eb260133-5462-47a4-bbff-0199da996ce3",
                },
                new AppRole
                {
                    Id = 4,
                    Name = "Sales",
                    NormalizedName = "SALES",
                    ConcurrencyStamp = "75ca2acb-a23f-4a92-8552-09b0d0068894",
                }
            };

            return roles;
        }
    }
}