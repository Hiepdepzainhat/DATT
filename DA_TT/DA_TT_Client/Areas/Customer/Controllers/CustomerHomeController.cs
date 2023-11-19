using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DA_TT_Client.Areas.Customer.Controllers
{
    public class CustomerHomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public List<GioHangItem> gioHangItems { get; set; } = new List<GioHangItem>();
        public List<DonHangChiTiet> donHangChiTiets { get; set; } = new List<DonHangChiTiet>();
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
        [HttpGet]
        public async Task<IActionResult> Detail(Guid Id)
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            if (lstSp == null)
            {
                return NotFound();
            }
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            var laptop = lstSpOk.FirstOrDefault(x => x.Id == Id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewBag.laptop = laptop;
            return View(laptop);
        }
        public async Task<IActionResult> AddToCart(Guid id, int quantity)
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            var laptop = lstSpOk.FirstOrDefault(x => x.Id == id);
            if (laptop == null)
            {
                return NotFound("Sản Phẩm Đã hết hàng");
            }
            string json = Request.Cookies["MyCart"];
            List<GioHangItem> myListCartItem = new List<GioHangItem>();
            if (json != null)
            {
                myListCartItem = JsonConvert.DeserializeObject<List<GioHangItem>>(json);
            }

            var existingItem = myListCartItem.FirstOrDefault(x => x.IdSanPham == laptop.Id);
            if (existingItem != null)
            {
                // Nếu sách đã có, tăng số lượng lên
                existingItem.Soluong += quantity;
                existingItem.ThanhTien = existingItem.DonGia * existingItem.Soluong;
            }
            else
            {
                GioHangItem item = new GioHangItem();
                item.ID = Guid.NewGuid();
                item.IdSanPham = laptop.Id;
                item.IdGioHang = null;
                item.ItemName = laptop.TenSanPham;
                item.DonGia = laptop.GiaBan;
                item.Image = laptop.Image;
                item.Soluong = 1;
                item.ThanhTien = item.DonGia * item.Soluong;

                myListCartItem.Add(item);
            }


            string updateJson = JsonConvert.SerializeObject(myListCartItem);
            Response.Cookies.Append("MyCart", updateJson);
            return RedirectToAction("MyCart", "CustomerHome", new {area = "Customer"});
        }
        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            if (lstSp == null)
            {
                return NotFound();
            }
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            ViewBag.lstLapTop = lstSpOk;
            string json = Request.Cookies["MyCart"];
            if (json != null)
            {
                List<GioHangItem> myListCartItem = JsonConvert.DeserializeObject<List<GioHangItem>>(json);
                ViewBag.myListCartItem = myListCartItem;
                decimal? subTotal = 0;
                foreach (var item in myListCartItem)
                {
                    subTotal += item.ThanhTien;
                    ViewBag.subTotal = subTotal;
                }
            }
            return View();
        }
        public async Task<IActionResult> InBill()
        {
            decimal? subTotal = 0;
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            if (lstSp == null)
            {
                return NotFound();
            }
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            string json = Request.Cookies["MyCart"];
            if (json != null)
            {
                List<GioHangItem> myListCartItem = JsonConvert.DeserializeObject<List<GioHangItem>>(json);
                ViewBag.myListCartItem = myListCartItem;
                foreach (var item in myListCartItem)
                {
                    subTotal += item.ThanhTien;
                    ViewBag.subTotal = subTotal;
                }
                string jsonUser = Request.Cookies["User"];
                if(jsonUser != null)
                {
                    NguoiDung nd = JsonConvert.DeserializeObject<NguoiDung>(jsonUser);


                    DonHang bill = new DonHang();
                    bill.Id = Guid.NewGuid();
                    bill.IdNguoiNhan = nd.Id;
                    bill.NgayDatHang = DateTime.Now;
                    bill.SDTNhanHang = nd.SoDienThoai;
                    bill.TienShip = 100000;
                    bill.TongTien = subTotal + bill.TienShip;
                    bill.TrangThai = 1;

                    string urlDM = $"https://localhost:7290/api/DonHang/CreateDonHang?IdDonHang={bill.Id}&IdNguoiNhan={bill.IdNguoiNhan}&ngaydathang={bill.NgayDatHang}&sdtnhanhang={bill.SDTNhanHang}&tongtien={bill.TongTien}";
                    var content = new StringContent(JsonConvert.SerializeObject(bill), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(urlDM, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Response.Cookies.Delete("MyCart");
                        return RedirectToAction("Index", "CustomerHome", new { area = "Customer" });
                    }
                    return BadRequest("Có lỗi sảy ra khi thanh toán");
                }

            }
            return NotFound("Không thể tạo hóa đơn do không có sản phẩm trong giỏ hàng");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
