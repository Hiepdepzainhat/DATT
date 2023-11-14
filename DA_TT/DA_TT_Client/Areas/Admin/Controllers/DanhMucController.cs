using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        private readonly HttpClient _httpClient;
        public DanhMucController()
        {
            _httpClient = new HttpClient();
        }
        public int pageSize = 6;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListDanhMuc()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);
            return View(lstDM);
        }
        public IActionResult CreateDanhMuc()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDanhMuc(DanhMuc dm)
        {
            string urlDM = $"https://localhost:7290/api/DanhMuc/CreateDanhMuc?ten={dm.Ten}&mota={dm.Mota}";
            var content = new StringContent(JsonConvert.SerializeObject(dm), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(urlDM, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListDanhMuc", "DanhMuc", new { area = "Admin" });
            }
            TempData["ErrorMessage"] = "Thêm Thất Bại";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DanhMucDetail(Guid Id)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);
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
        [HttpGet]
        public async Task<IActionResult> UpdateDanhMuc(Guid Id)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);
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
        public async Task<IActionResult> UpdateDanhMuc(Guid id, DanhMuc cp)
        {
            string urlAPICoupon = $"https://localhost:7290/api/DanhMuc/UpdateDanhMuc/{id}";
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
