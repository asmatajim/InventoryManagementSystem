using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Users;

namespace KTMPOS.BAL.Services.Users
{
    public interface ILoginService
    {
        Task<Output<LoginRead>> AuthenticateAsync(LoginRequest request);

        Task<Output> CreateAsync(RegisterRequest request);
    }
}