using Microsoft.AspNetCore.Mvc;

namespace DA_TT_Client.Areas.Admin.Controllers
{
	public class AdminHomeController : Controller
	{
		private readonly HttpClient _httpClient;
        public AdminHomeController()
        {
            _httpClient = new HttpClient();
        }
        public IActionResult Index()
		{
			return View();
		}

	}
}
