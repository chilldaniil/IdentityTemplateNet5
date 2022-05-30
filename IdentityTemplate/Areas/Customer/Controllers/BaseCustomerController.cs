using App.DataContract.Entities.Enums;
using IdentityTemplate.Controllers;
using IdentityTemplate.MvcCustomization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Customer.Controllers
{
    [Area(nameof(ApplicationRoles.Customer))]
    [AreaAuthorization(nameof(ApplicationRoles.Customer))]
    public class BaseCustomerController : GlobalBaseController
    {

    }
}
