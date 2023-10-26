using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            string urlAPIDanhMuc = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIDM);
            if(lstDM == null)
            {
                return NotFound();
            }
            ViewBag.hangSanXuats = lstDM;
            return View(lstDM);
        }
    }
}
