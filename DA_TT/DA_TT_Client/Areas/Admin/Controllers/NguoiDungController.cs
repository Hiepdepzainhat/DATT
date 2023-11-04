using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly HttpClient _httpClient;
        public NguoiDungController()
        {
            _httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachNguoiDung()
        {
            string urlAPI = $"https://localhost:7290/api/NguoiDung/GetAllNguoiDung";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstnd = JsonConvert.DeserializeObject<List<NguoiDung>>(dataAPI);
            if (lstnd == null)
            {
                return NotFound();
            }
            string urlCV = $"https://localhost:7290/api/ChucVu/GetAllChucVu";
            var responCV = await _httpClient.GetAsync(urlCV);
            string dataCV = await responCV.Content.ReadAsStringAsync();
            var lstcv = JsonConvert.DeserializeObject<List<ChucVu>>(dataCV);
            var cvND = lstcv.FirstOrDefault(x => x.TenChucVu == "Customer");
            if (cvND == null)
            {
                return NotFound();
            }
            var lstKH = lstnd.Where(x => x.IdChucVu == cvND.Id).ToList();
            if(lstKH == null)
            {
                return NotFound();
            }
            ViewBag.lstKH = lstKH;
            return View(lstKH);
        }
    }
}
