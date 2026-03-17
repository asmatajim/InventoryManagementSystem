using FluentValidation;

using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Users;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Users;
using KTMPOS.DAL.Repositories.Users;

namespace KTMPOS.BAL.Services.Users
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IValidator<LoginRequest> _validator;
        private readonly IValidator<RegisterRequest> _registerValidator;

        public LoginService(ILoginRepository loginRepository, IValidator<LoginRequest> validator,
                            IValidator<RegisterRequest> registerValidator)
        {
            _loginRepository = loginRepository;
            _validator = validator;
            _registerValidator = registerValidator;
        }

        public async Task<Output<LoginRead>> AuthenticateAsync(LoginRequest request)
        {
            try
            {
                var result = await _validator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed<LoginRead>(result);
                }

                var user = await _loginRepository.LoginAsync(request.UserName, request.Password);
                if(user is null)
                {
                    return OutputConverter.SetFailed<LoginRead>("Invalid username or password.");
                }

                LoginRead response = new()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                return OutputConverter.SetSuccess([response]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<LoginRead>(ex.Message);
            }
        }

        public async Task<Output> CreateAsync(RegisterRequest request)
        {
            try
            {
                var result = await _registerValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                AppUser appUser = new()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                };
                var identityResult = await _loginRepository.CreateAsync(appUser, request.Password);
                if(identityResult.Succeeded)
                {
                    return OutputConverter.SetSuccess("User registered successfully.");
                }

                string errors = String.Join(Environment.NewLine, identityResult.Errors.Select(e => e.Description));
                return OutputConverter.SetFailed(errors);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<LoginRead>(ex.Message);
            }
        }
    }
}