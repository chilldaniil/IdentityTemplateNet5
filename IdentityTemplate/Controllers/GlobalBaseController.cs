using App.DataContract.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityTemplate.Controllers
{
    public class GlobalBaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                object routeValues = new
                {
                    area = string.Empty,
                    controller = "Dashboard",
                    action = "Index",
                    message = string.Empty
                }; ;

                if (User.IsInRole(nameof(ApplicationRoles.Admin)))
                {
                    routeValues = new
                    {
                        area = nameof(ApplicationRoles.Admin),
                        controller = "Dashboard",
                        action = "Index",
                        message = string.Empty
                    };
                }
                if (User.IsInRole(nameof(ApplicationRoles.Customer)))
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

            base.OnActionExecuted(context);
        }
    }
}
