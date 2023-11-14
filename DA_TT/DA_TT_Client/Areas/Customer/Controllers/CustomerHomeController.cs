using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DA_TT_Client.Areas.Customer.Controllers
{
    public class CustomerHomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public CustomerHomeController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);
            if(lstDM == null)
            {
                return NotFound();
            }
            var DMGaming = lstDM.FirstOrDefault(x => x.Ten == "Laptop Gaming");
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if(lstSpOk == null)
            {
                return NotFound();
            }
            var lstSPselectNew = lstSpOk.OrderByDescending(x => x.NgayNhap).Take(6).ToList();
            ViewBag.lstSPselectNew = lstSPselectNew;
            var lstSPselectSLdaban = lstSpOk.OrderByDescending(x => x.SoLuongDaBan).Take(8).ToList();
            ViewBag.lstSPselectSLdaban = lstSPselectSLdaban;
            if(DMGaming != null)
            {
                var lstSpGaming = lstSpOk.Where(x => x.IdDanhMuc == DMGaming.Id);
                ViewBag.lstSpGaming = lstSpGaming;
            }
            
            return View();
        }
    }
}
