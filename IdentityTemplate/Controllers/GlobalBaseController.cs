using System.Linq;
using System.Security.Claims;
using App.DataContract.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityTemplate.Controllers
{
    public class GlobalBaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return;
            }

            var area = RouteData.Values["Area"] as string;
            var userRole = User.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            if (userRole == area)
            {
                return;
            }

            object routeValues = new
            {
                area = string.Empty,
                controller = "Dashboard",
                action = "Index",
                message = string.Empty
            };

            if (userRole == nameof(ApplicationRoles.Admin) && area != userRole)
            {
                routeValues = new
                {
                    area = nameof(ApplicationRoles.Admin),
                    controller = "Dashboard",
                    action = "Index",
                    message = string.Empty
                };
            }
            if (userRole == nameof(ApplicationRoles.Customer) && area != userRole)
            {
                routeValues = new
                {
                    area = nameof(ApplicationRoles.Customer),
                    controller = "Home",
                    action = "Index",
                    message = string.Empty
                };
            }

            context.Result = new RedirectToRouteResult(routeValues);
        }

        protected string GetRedirectUrl(string userRole)
        {
            string area = string.Empty;
            string controller = "Home";
            string action = "Index";

            if (userRole == nameof(ApplicationRoles.Admin))
            {
                area = nameof(ApplicationRoles.Admin);
                controller = "Dashboard";
                action = "Index";
            }
            if (userRole == nameof(ApplicationRoles.Customer))
            {
                area = nameof(ApplicationRoles.Customer);
                controller = "Home";
                action = "Index";
            }

            // TODO: Read culture from claim if authorized
            // lang = GetLangFromClaim

            return Url.Action(action, controller, new { Area = area });
        }
    }
}
