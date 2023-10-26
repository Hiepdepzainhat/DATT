using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class CouponController : Controller
    {
        private readonly HttpClient _httpClient;
        public CouponController()
        {
            _httpClient = new HttpClient();
        }
        public int pageSize = 6;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllCouponManager()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<Coupon>>(dataAPIDM);

            return View(lstDM);
        }
    }
}
