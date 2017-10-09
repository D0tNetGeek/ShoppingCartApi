using System;
using System.Web.Mvc;
using Domain.Core.Models;
using Domain.Core.Services.Contracts;

namespace ShoppingCartMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var customer = _customerService.GetInfo(User.Identity.Name);

            if (customer != null)
                ViewBag.CustomerType = Enum.GetName(typeof(CustomerType), customer.CustomerType);

            return View();
        }
    }
}