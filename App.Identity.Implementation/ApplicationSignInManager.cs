using System.Linq;
using System.Threading.Tasks;
using App.DataContract.Entities.Enums;
using App.DataContract.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Identity.Implementation
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        private readonly ApplicationUserManager _userManager;

        public ApplicationSignInManager(
            ApplicationUserManager userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            IAuthenticationSchemeProvider schemeProvider,
            IUserConfirmation<ApplicationUser> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider, confirmation)
        {
            _userManager = userManager;
        }

        public async Task<SignInResult> PasswordSignWithRoleInAsync(ApplicationUser user, string password, bool isPersistent, bool lockoutOnFailure, params ApplicationRoles[] roles)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var isUserInRightRole = roles.Any(role => role.ToString() == userRoles[0]);

            // Fastest way to get failed result for wrong role
            password = isUserInRightRole ? password : string.Empty;

            var result = await base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

            return result;
        }
    }
}
