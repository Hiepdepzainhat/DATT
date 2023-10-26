using Microsoft.AspNetCore.Mvc;

namespace DA_TT_Client.Areas.Shipper.Controllers
{
    public class ShipperHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
