using App.DataContract.Entities.Enums;
using IdentityTemplate.Controllers;
using IdentityTemplate.MvcCustomization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Admin.Controllers
{
    [Area(nameof(ApplicationRoles.Admin))]
    [AreaAuthorization(nameof(ApplicationRoles.Admin))]
    public class BaseAdminController : GlobalBaseController
    {
    }
}
