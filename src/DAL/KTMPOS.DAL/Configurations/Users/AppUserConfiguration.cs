using KTMPOS.DAL.Entities.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.Users
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
            .HasIndex(u => u.UserName)
            .IsUnique();

            builder
            .HasIndex(u => u.Email)
            .IsUnique();

            builder
            .Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(50);

            builder
            .Property(u => u.NormalizedUserName)
            .IsRequired()
            .HasMaxLength(50);

            builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);

            builder
            .Property(u => u.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(50);

            builder
            .Property(u => u.PasswordHash)
            .IsRequired();

            builder
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .ToTable(b => b.HasCheckConstraint("CK_AspNetUsers_NormalizedUserName", "[NormalizedUserName]=UPPER(UserName)"));

            builder
           .ToTable(b => b.HasCheckConstraint("CK_AspNetUsers_NormalizedEmail", "[NormalizedEmail]=UPPER(Email)"));

            builder
            .HasData(GetUsers());
        }

        private List<AppUser> GetUsers()
        {
            string userName = "sumit";
            string email = "sbhattarai@q.com";
            DateTime createdDate = Convert.ToDateTime("01/08/2026");
            return new List<AppUser>
            {
                new AppUser
                {
                    Id = 1,
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    //PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Sumit1@3"),
                    PasswordHash = "AQAAAAIAAYagAAAAEMCfVPeG+3aPUfRQdkhuRBFQxJWGUOEKaxWiuh6fYQ5nWaai6V76F2zrT9BOY2qNDA==",
                    ConcurrencyStamp = "c4e1cf62-ba8a-4a18-9a8d-75d1d55b36d0",
                    SecurityStamp = "03712bef-c203-4a63-9744-6f7ba748ee24",
                    CreatedDate = createdDate,
                }
            };
        }
    }
}