using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class HangSanXuatController : Controller
    {
        private readonly HttpClient _httpClient;
        public HangSanXuatController()
        {
            _httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachHangSanXuat()
        {
            string urlHSX = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHSX = await _httpClient.GetAsync(urlHSX);
            string dataAPIHSX = await responHSX.Content.ReadAsStringAsync();
            var lstHSX = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHSX);
            if(lstHSX == null)
            {
                return NotFound();
            }
            ViewBag.hangSanXuats = lstHSX;
            return View(lstHSX);
        }
        public IActionResult CreateHangSX()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHangSX(HangSanXuat hsx)
        {
            string urlHSX = $"https://localhost:7290/api/HangSanXuat/CreateHangSX?ten={hsx.TenHangSanXuat}&mota={hsx.Desciption}";
            var content = new StringContent(JsonConvert.SerializeObject(hsx), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(urlHSX, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DanhSachHangSanXuat", "HangSanXuat", new { area = "Admin" });
            }
            TempData["ErrorMessage"] = "Thêm Thất Bại";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> HSXChiTiet(Guid id)
        {
            var urlHSX = $"https://localhost:7079/api/HangSanXuat/GetAllHangSX";
            var responHSX = await _httpClient.GetAsync(urlHSX);
            string apiDataHSX = await responHSX.Content.ReadAsStringAsync();
            var lstHSX = JsonConvert.DeserializeObject<List<HangSanXuat>>(apiDataHSX);
            if(lstHSX == null)
            {
                return NotFound();
            }
            var HSX = lstHSX.FirstOrDefault(x => x.Id == id);
            if (HSX == null)
            {
                return BadRequest();
            }
            else
            {
                return View(HSX);
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHSX(Guid id)
        {
            var urlHSX = $"https://localhost:7079/api/HangSanXuat/GetAllHangSX";
            var responHSX = await _httpClient.GetAsync(urlHSX);
            string apiDataHSX = await responHSX.Content.ReadAsStringAsync();
            var lstHSX = JsonConvert.DeserializeObject<List<HangSanXuat>>(apiDataHSX);
            if (lstHSX == null)
            {
                return NotFound();
            }
            var HSX = lstHSX.FirstOrDefault(x => x.Id == id);
            if (HSX == null)
            {
                return BadRequest();
            }
            else
            {
                return View(HSX);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHSX(Guid id,HangSanXuat hsx)
        {
            var urlHSX = $"https://localhost:7079/api/HangSanXuat/UpdateHangSX/{id}";
            var content = new StringContent(JsonConvert.SerializeObject(hsx), Encoding.UTF8, "application/json");
            var respon = await _httpClient.PutAsync(urlHSX, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("DanhSachHangSanXuat", "HangSanXuat", new { area = "Admin" });

        }
    }
}
