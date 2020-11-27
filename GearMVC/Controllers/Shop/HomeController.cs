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

namespace GearMVC.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly ILinhKienRepository _linhkienRepo;
        private readonly IHoaDonRepository _hoadonRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger,
                              ILinhKienRepository linhkienRepo,
                              IHoaDonRepository hoadonRepository,
                              IMapper mapper,
                              UserManager<ApplicationUser> userManager
                )
        {
            _logger = logger;
            _linhkienRepo = linhkienRepo;
            _hoadonRepository = hoadonRepository;
            _userManager = userManager;
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
            if(product == null) return View("~/Views/Error/404.cshtml");
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
            foreach(var item in products)
            {
                item.DonGias = item.DonGias.Where(i => i.ApDung).ToList();
                var dto = mapper.Map<LinhKienDTO>(item);
                result.Add(dto);
            }
            return View(result);
        }

        [Authorize(Roles = "Admin,Khách hàng,Quản lý")]
        [HttpGet("user/profie-orders/{page?}")]
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

            return View(new ProfileOrderData() { User = userDTO, HoaDons = hoadonsDTO, Page = page});
        }
    }
    public class ProfileOrderData
    {
        public int Page { get; set; }
        public UserDTO User { get;set; }
        public List<HoaDonDTO> HoaDons { get; set; }
    }
}
