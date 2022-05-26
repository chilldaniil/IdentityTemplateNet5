using App.DataContract.Entities.Enums;
using IdentityTemplate.MvcCustomization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Customer.Controllers
{
    [Area(nameof(ApplicationRoles.Customer))]
    [AreaAuthorization(nameof(ApplicationRoles.Customer))]
    public class BaseCustomerController : Controller
    {

    }
}
