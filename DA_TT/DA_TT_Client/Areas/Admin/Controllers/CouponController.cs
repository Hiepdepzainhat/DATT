using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        public IActionResult CreateCoupon()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(Coupon cp)
        {
            cp.Id = Guid.NewGuid();
            string urlAPICoupon = $"https://localhost:7290/api/Coupon/CreateCoupon?ten={cp.TenCoupon}&phantramgiam{cp.PhanTramGiam}&ngaydb={cp.NgayBatDau}&ngaykt={cp.NgayKetThuc}";
            var content = new StringContent(JsonConvert.SerializeObject(cp), Encoding.UTF8,"application/json");
            var respon = await _httpClient.PostAsync(urlAPICoupon, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("AllCouponManager","Coupon", new {area = "Admin"});
        }
        [HttpGet]
        public async Task<IActionResult> CouponDetail(Guid Id)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<Coupon>>(dataAPIDM);
            if(lstDM == null)
            {
                return NotFound();
            }
            var cp = lstDM.FirstOrDefault(x => x.Id == Id);
            if(cp == null)
            {
                return NotFound();
            }
            return View(cp);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCoupon(Guid Id)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<Coupon>>(dataAPIDM);
            if (lstDM == null)
            {
                return NotFound();
            }
            var cp = lstDM.FirstOrDefault(x => x.Id == Id);
            if (cp == null)
            {
                return NotFound();
            }
            return View(cp);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCoupon(Guid id, Coupon cp)
        {
            string urlAPICoupon = $"https://localhost:7290/api/Coupon/UpdateCoupon/{id}";
            var content = new StringContent(JsonConvert.SerializeObject(cp), Encoding.UTF8, "application/json");
            var respon = await _httpClient.PutAsync(urlAPICoupon, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("AllCouponManager", "Coupon", new { area = "Admin" });
        }

    }
}
