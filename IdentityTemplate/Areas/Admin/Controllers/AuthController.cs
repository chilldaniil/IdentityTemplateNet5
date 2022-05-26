using System.Threading.Tasks;
using App.DataContract.Entities.Identity;
using App.Identity.Implementation;
using IdentityTemplate.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseAdminController
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
                var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
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
