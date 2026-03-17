using KTMPOS.DAL.Entities.Users;

using Microsoft.AspNetCore.Identity;

namespace KTMPOS.DAL.Repositories.Users
{
    public interface ILoginRepository
    {
        Task<AppUser> LoginAsync(string userName, string password);

        Task<IdentityResult> CreateAsync(AppUser appUser, string password);
    }
}