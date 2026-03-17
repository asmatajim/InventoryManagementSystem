using KTMPOS.BAL.Services.Users;
using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Users;
using KTMPOS.DAL.Entities.Users;
using KTMPOS.Web.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(ILoginService loginService, SignInManager<AppUser> signInManager)
        {
            _loginService = loginService;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request, string returnUrl = null)
        {
            var result = await _loginService.AuthenticateAsync(request);
            if(result.Status == Status.Success)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);
                if(signInResult.Succeeded)
                {
                    if(!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData[Message.ErrorMessage] = "Invalid Login.";
                }
            }
            else
            {
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [Authorize(Policy = Policy.UserCreate)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = Policy.UserCreate)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _loginService.CreateAsync(request);
            if(result.Status == Status.Success)
            {
                TempData[Message.SuccessMessage] = "User registered successfully, please login.";
                return RedirectToAction(nameof(Login));
            }

            TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
            return View();
        }
    }
}