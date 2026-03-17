using KTMPOS.DAL.Entities.Users;

using Microsoft.AspNetCore.Identity;

namespace KTMPOS.DAL.Repositories.Users
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> LoginAsync(string userName, string password)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            if(user is null)
            {
                return null;
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            return isPasswordValid ? user : null;
        }

        public async Task<IdentityResult> CreateAsync(AppUser appUser, string password)
        {
            var result = await _userManager.CreateAsync(appUser, password);
            return result;
        }
    }
}