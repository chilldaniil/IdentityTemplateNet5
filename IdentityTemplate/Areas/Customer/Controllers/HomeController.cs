using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Customer.Controllers
{
    public class HomeController : BaseCustomerController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
