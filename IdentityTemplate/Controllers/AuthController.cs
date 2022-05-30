using System.Threading.Tasks;
using App.DataContract.Entities.Enums;
using App.Identity.Implementation;
using IdentityTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Controllers
{
    [AllowAnonymous]
    public class AuthController : GlobalBaseController
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;

        public AuthController(
            ApplicationSignInManager signInManager,
            ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                var (result, role) = await _signInManager.PasswordSignInWithRoleAsync(user, viewModel.Password, true, false, ApplicationRoles.Customer);
                if (result.Succeeded)
                {
                    return Redirect(GetRedirectUrl(role));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
