using App.DataContract.Entities.Enums;
using IdentityTemplate.MvcCustomization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Admin.Controllers
{
    [Area(nameof(ApplicationRoles.Admin))]
    [AreaAuthorization(nameof(ApplicationRoles.Admin))]
    public class BaseAdminController : Controller
    {
    }
}
