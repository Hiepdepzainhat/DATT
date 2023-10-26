using Microsoft.AspNetCore.Mvc;

namespace DA_TT_Client.Areas.Customer.Controllers
{
    public class CustomerHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
