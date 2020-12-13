using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.ViewModels;
using Domain.IRepository;
using AutoMapper;
using Application.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Domain.Entity;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Html;
using Insfrastucture.Repository;
using System.Text.RegularExpressions;

namespace GearMVC.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly ILinhKienRepository _linhkienRepo;
        private readonly IHoaDonRepository _hoadonRepository;
        private readonly IGioHangRepository _giohangRepo;
        private readonly ILoaiLinhKienRepository _loailinhkienRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger,
                              ILinhKienRepository linhkienRepo,
                              IHoaDonRepository hoadonRepository,
                              IGioHangRepository giohangRepo,
                              ILoaiLinhKienRepository loailinhkienRepo,
                              IMapper mapper,
                              UserManager<ApplicationUser> userManager
                )
        {
            _logger = logger;
            _linhkienRepo = linhkienRepo;
            _hoadonRepository = hoadonRepository;
            _userManager = userManager;
            _giohangRepo = giohangRepo;
            _loailinhkienRepo = loailinhkienRepo;
            this.mapper = mapper;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var list = await _linhkienRepo.getNewItems();
            var result = new List<List<LinhKienDTO>>();
            List<LinhKienDTO> result_item = new List<LinhKienDTO>();
            foreach (LinhKien item in list)
            {
                //item.DonGias = item.DonGias.Where(i => i.ApDung).ToList();
                var dto = mapper.Map<LinhKienDTO>(item);
                result_item.Add(dto);
            }
            result.Add(result_item);


            list = await _linhkienRepo.getTopSelling();
            result_item = new List<LinhKienDTO>();
            foreach (LinhKien item in list)
            {
                var dto = mapper.Map<LinhKienDTO>(item);
                result_item.Add(dto);
            }
            result.Add(result_item);
            return View(result);
        }

        [HttpGet("product/detail/{id?}")]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _linhkienRepo.getById(id);
            if (product == null) return View("~/Views/Error/404.cshtml");
            product.DonGias = product.DonGias.Where(i => i.ApDung).ToList();
            var result = mapper.Map<LinhKienDTO>(product);
            return View(result);
        }

        [HttpGet("product/category/{id?}")]
        public async Task<IActionResult> Category(int id)
        {
            var products = await _linhkienRepo.Filter(searchCategory: id);
            if (products.Count() == 0) return View("~/Views/Error/404.cshtml");
            var result = new List<LinhKienDTO>();
            foreach (var item in products)
            {
                item.DonGias = item.DonGias.Where(i => i.ApDung).ToList();
                var dto = mapper.Map<LinhKienDTO>(item);
                result.Add(dto);
            }
            var list = new HtmlString(JsonConvert.SerializeObject(result, Formatting.None,
           new JsonSerializerSettings
           {
               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
           }));
            var tenloai = (await _loailinhkienRepo.getById(id)).Ten;
            ViewData["list"] = list;
            ViewData["TenLoai"] = tenloai;
            return View();
        }

        [HttpGet("product/search")]
        public async Task<IActionResult> Search(string str)
        {
            var products = await _linhkienRepo.Filter(searchString: str);
            var result = new List<LinhKienDTO>();
            foreach (var item in products)
            {
                item.DonGias = item.DonGias.Where(i => i.ApDung).ToList();
                var dto = mapper.Map<LinhKienDTO>(item);
                result.Add(dto);
            }
            var list = new HtmlString(JsonConvert.SerializeObject(result, Formatting.None,
           new JsonSerializerSettings
           {
               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
           }));
            ViewData["list"] = list;
            return View();
        }

        [Authorize]
        [HttpGet("user/profile-orders/{page?}")]
        public async Task<IActionResult> ProfileOrders(int page)
        {
            var user = await _userManager.GetUserAsync(User);
            var userDTO = mapper.Map<UserDTO>(user);
            var orders = await _hoadonRepository.getByUser(user.Id);
            var hoadonsDTO = new List<HoaDonDTO>();
            foreach (var item in orders)
            {
                var dto = mapper.Map<HoaDonDTO>(item);
                hoadonsDTO.Add(dto);
            }
            return View("ProfileOrders", new ProfileOrderData() {User = userDTO, HoaDons = hoadonsDTO, Page = page });
        }

        [Authorize]
        [HttpPost("user/profile-orders/updateprofile")]
        public async Task<ActionResultDTO> UpdateProfile([FromBody] EditUserDTO dto)
        {
            if(!InputIsValid(dto)) return new ActionResultDTO { Code = 400, Message = "Bad request" };
            var user = await _userManager.GetUserAsync(User);
            var changepass_result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!changepass_result.Succeeded)
            {
                if(changepass_result.Errors.First().Code == "PasswordMismatch")
                    return new ActionResultDTO { Code = 400, Message = "Mật khẩu hiện tại không chính xác" };
                return new ActionResultDTO { Code = 400, Message = "Bad request" };
            }
            
            user.HoTen = dto.HoTen;
            user.PhoneNumber = dto.PhoneNumber;
            user.DiaChi = dto.DiaChi;
            user.GioiTinh = dto.GioiTinh;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return new ActionResultDTO { Code = 200 };
            else
                return new ActionResultDTO { Code = 500 , Message = "Internal server error"};
        }

        private bool InputIsValid(EditUserDTO user)
        {

            if (string.IsNullOrEmpty(user.PhoneNumber) || 
                string.IsNullOrEmpty(user.HoTen) || 
                string.IsNullOrEmpty(user.DiaChi) ||
                string.IsNullOrEmpty(user.CurrentPassword) ||
                string.IsNullOrEmpty(user.NewPassword) ||
                string.IsNullOrEmpty(user.NewPasswordConfirm))
            {
                return false;
            }
            var phoneregex = new Regex(@"^[0-9]+$");
            var passregex = new Regex(@".{5,}");
            if (!phoneregex.IsMatch(user.PhoneNumber))
            {
                return false;
            }
            if (!passregex.IsMatch(user.CurrentPassword) || !passregex.IsMatch(user.NewPassword) || !passregex.IsMatch(user.NewPasswordConfirm))
            {
                
                return false;
            }
            if (user.NewPassword != user.NewPasswordConfirm)
            {
                return false;
            }
            return true;
        }
    

        [Authorize]
        [HttpGet("user/cart")]
        public  IActionResult Cart()
        {
            return View();
        }
        [Authorize]
        [HttpGet("user/getcart")]
        public async Task<string> GetCart()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _giohangRepo.getByUser(user.Id);
            var result = new List<GioHangDTO>();
            foreach (var item in list)
            {
                result.Add(mapper.Map<GioHangDTO>(item));
            }
            var str = JsonConvert.SerializeObject(result, Formatting.None,
              new JsonSerializerSettings
              {
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
              });
            return str;
        }

        [Authorize]
        [HttpGet("user/checkout")]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _giohangRepo.getByUser(user.Id);
            var cartDto = new List<GioHangDTO>();
            foreach(var item in cart)
            {
                cartDto.Add(mapper.Map<GioHangDTO>(item));
            }
            var cart_json = JsonConvert.SerializeObject(cartDto, Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            ViewBag.User = mapper.Map<UserDTO>(user);
            ViewBag.Cart = cart_json;
            return View();
        }

        [Authorize]
        [HttpGet("user/createorder")]
        public async Task<bool> CreateOrder(string pttt)
        {
            var userid =  _userManager.GetUserId(User);
            var list = await _giohangRepo.getByUser(userid);
            if (list.Count() < 1) return false;
            decimal total = 0;
            var cthds = new List<ChiTietHD>();
            foreach (var item in list)
            {
                var sale = (decimal) item.LinhKien.DonGias.FirstOrDefault().GiamGia;
                var price_unit = item.LinhKien.DonGias.FirstOrDefault().DonGiaBan;
                var price = (price_unit - price_unit * sale / 100) * item.SoLuong;
                total += price;
                var cthd = new ChiTietHD
                {
                    LinhKien = item.LinhKien,
                    SoLuongBan = item.SoLuong,
                    DonGia = price

                };
                cthds.Add(cthd);

            }
            var hoadon = new HoaDon
            {
                NgayLapHD = DateTime.Now,
                UserId = userid,
                TinhTrang = Status.ChoXacNhan,
                ChiTietHDs = cthds,
                PhuongThucThanhToan = pttt,
                TiGia = total,
            };
            await _hoadonRepository.Add(hoadon);
            await _giohangRepo.DeleteRange(list);
            return true;
        }
        [Authorize]
        [HttpGet("user/cancelorder")]
        public async Task<bool> CancelOrder(int id)
        {
            var userid = _userManager.GetUserId(User);
            var order = await _hoadonRepository.getById(id);
            if (order.UserId != userid) return false;
            if (order.TinhTrang != Status.ChoXacNhan) return false; ;
            order.TinhTrang = Status.DaHuy;
            await _hoadonRepository.Update(order);
            return true;
        }
        [Authorize]
        [HttpGet("cart/addtocart")]
        public async Task<bool> AddToCart( int linhkienid,  int soluong)
        {
            if (linhkienid <= 0 || soluong <= 0) return false;
            var userid = _userManager.GetUserId(User);
            //kiểm tra tồn kho
            var linhkien = await _linhkienRepo.getById(linhkienid);
            var tonkho = linhkien.SLTonKho;
            if (tonkho < soluong) return false;
            //tăng soluong của item nếu đã tồn tại 
            var giohang_item = await _giohangRepo.getById(userid, linhkienid);
            if(giohang_item != null)
            {
                giohang_item.SoLuong += soluong;
                if (giohang_item.SoLuong > tonkho) giohang_item.SoLuong = tonkho;
                 await _giohangRepo.Update(giohang_item);
                return true;
            }
            var item = new GioHang
            {
                LinhKienId = linhkienid,
                SoLuong = soluong,
                UserId = userid
            };
            await _giohangRepo.Add(item);
            return true;
        }
        [Authorize]
        [HttpGet("cart/getcartnum")]
        public async Task<int> GetCartNum()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _giohangRepo.getCartsNum(userId);
            return result;
        }

        [Authorize]
        [HttpGet("cart/deleteitem")] 
        public async Task<bool> DeleteCartItem(int linhkienid)
        {
            if (linhkienid <= 0) return false;
            var userid = _userManager.GetUserId(User);
            var item = await _giohangRepo.getById(userid, linhkienid);
            await _giohangRepo.Delete(item);
            return true;
        }
        [Authorize]
        [HttpGet("cart/updateitem")]
        public async Task<bool> UpdateItem(int linhkienid, int soluong)
        {
            if (linhkienid <= 0 || soluong <= 0) return false;
            //kiểm tra tồn kho
            var linhkien = await _linhkienRepo.getById(linhkienid);
            if (linhkien.SLTonKho < soluong) return false;
            
            var userid = _userManager.GetUserId(User);
            var item = await _giohangRepo.getById(userid, linhkienid);
            item.SoLuong = soluong;
            await _giohangRepo.Update(item);
            return true;
        }
        
    }
    public class ProfileOrderData
    {
        public int Page { get; set; }
        public UserDTO User { get; set; }
        public List<HoaDonDTO> HoaDons { get; set; }
    }
}
