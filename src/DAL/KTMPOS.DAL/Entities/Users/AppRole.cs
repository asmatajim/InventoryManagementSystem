using Microsoft.AspNetCore.Identity;

namespace KTMPOS.DAL.Entities.Users
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime? CreatedDate { get; set; }
    }
}