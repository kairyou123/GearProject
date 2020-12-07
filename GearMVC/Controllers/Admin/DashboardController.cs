using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class DashboardController : Controller
    {
        public readonly IHoaDonRepository _hoadonRepo;
        public readonly ILinhKienRepository _lkRepo;
        public readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public DashboardController(IHoaDonRepository hoadonRepo, IMapper mapper, ILinhKienRepository lkRepo, IUserRepository userRepo)
        {
            _hoadonRepo = hoadonRepo;
            _mapper = mapper;
            _lkRepo = lkRepo;
            _userRepo = userRepo;
        }

        [HttpGet("getOrderThreeMonth")]
        public async Task<IActionResult> getOrderThreeMonth()
        {
            var list = await _hoadonRepo.getOrderThreeMonthAgoAndNow();

            if (list == null || list.Count() == 0)
            {
                return NotFound();
            }

            var dtoList = _mapper.Map<List<HoaDonDTO>>(list);

            var returnList = JsonConvert.SerializeObject(dtoList, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Ok(returnList);
        }

        public async Task<IActionResult> Index()
        {
            var linhKiens = await _lkRepo.getAll();
            var tongLinhKien = linhKiens.Count();


            var users = await _userRepo.getAllKhachHang();
            var tongKH = users.Count();

            var hoadons = await _hoadonRepo.getAll();
            var tongHD = hoadons.Count();

            ViewBag.TongLinhKien = tongLinhKien;
            ViewBag.TongKH = tongKH;
            ViewBag.TongHD = tongHD;

            var top10 = await _lkRepo.getTop10Product();
            var top10DTO = _mapper.Map<List<LinhKienDTO>>(top10);

            return View("~/Views/Admin/Dashboard.cshtml", top10DTO);
        }


    }
}