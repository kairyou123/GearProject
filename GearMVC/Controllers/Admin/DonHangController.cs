using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.ViewModels;
using AutoMapper;
using Domain.IRepository;
using GearMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/order")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class DonHangController : Controller
    {
        public readonly IHoaDonRepository _hoadonRepo;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 8;

        public DonHangController(IHoaDonRepository hoadonRepo, IMapper mapper)
        {
            _hoadonRepo = hoadonRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string searchString = "", string tinhTrang = "", string orderBy = "", DateTime fromDate = default, DateTime toDate = default, int page = 1)
        {
            if (searchString == null) searchString = "";
            if (orderBy == null) orderBy = "";

            var list = await _hoadonRepo.Filter(searchString, orderBy, tinhTrang, fromDate, toDate);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);

            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            List<HoaDonDTO> hoadonsDTO = _mapper.Map<List<HoaDonDTO>>(list);

            IndexViewModel<HoaDonDTO> returnList = PaginationServices<HoaDonDTO>.PaginationHoaDon(hoadonsDTO, page, ItemPerPage, pageCount, searchString, tinhTrang, orderBy, fromDate, toDate);

            return View("~/Views/Admin/DonHang/Index.cshtml", returnList);
        }

        [HttpGet("{id?}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var donHang = await _hoadonRepo.getById(id);

            if (donHang == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            var dto = _mapper.Map<HoaDonDTO>(donHang);

            return View("~/Views/Admin/DonHang/Edit.cshtml", dto);

        }

        [HttpPost("{id?}/edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, string tinhTrang)
        {
            var donHang = await _hoadonRepo.getById(id);

            donHang.TinhTrang = tinhTrang;

            await _hoadonRepo.Update(donHang);

            return Redirect("/admin/order");
        }


    }
}