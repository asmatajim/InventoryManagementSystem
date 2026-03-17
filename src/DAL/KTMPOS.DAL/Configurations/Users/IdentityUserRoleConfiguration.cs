using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTMPOS.DAL.Configurations.Users
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(GetIdentityUserRoles());
        }

        private List<IdentityUserRole<int>> GetIdentityUserRoles()
        {
            var userRoles = new List<IdentityUserRole<int>>
            {
                new IdentityUserRole<int>
                {
                     UserId = 1,
                     RoleId  = 1
                },
                new IdentityUserRole<int>
                {
                     UserId = 2,
                     RoleId  = 2
                },
                new IdentityUserRole<int>
                {
                     UserId = 3,
                     RoleId  = 3
                },
                new IdentityUserRole<int>
                {
                     UserId = 4,
                     RoleId  = 4
                }
            };

            return userRoles;
        }
    }
}