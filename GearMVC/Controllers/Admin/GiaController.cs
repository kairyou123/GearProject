using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Mapping;
using Application.ViewModels;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using GearMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/product")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class GiaController : Controller
    {
        public readonly IGiaRepository _giaRepo;
        public readonly ILinhKienRepository _lkRepo;
        public readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;

        public GiaController(IGiaRepository giaRepo, ILinhKienRepository lkRepo, IMapper mapper)
        {
            _giaRepo = giaRepo;
            _lkRepo = lkRepo;
            _mapper = mapper;
        }

        [HttpGet("{id?}/price")]
        public async Task<IActionResult> Index(int id, DateTime FromDate, DateTime ToDate, string ApDung = "0", int page = 1)
        {
            var linhkien = await _lkRepo.getById(id);

            if (linhkien == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            ViewBag.IdProduct = linhkien.Id;
            ViewBag.NameProduct = linhkien.TenLK;

            IEnumerable<DonGia> gias = new List<DonGia>();

            if (FromDate == DateTime.MinValue)
            {
                gias = await _giaRepo.getAll(linhkien.Id);
            }
            else
            {
                gias = await _giaRepo.Filter(linhkien.Id, FromDate, ToDate, ApDung);
            }

            double count = gias.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);

            gias = gias.Skip((page - 1) * ItemPerPage).Take(ItemPerPage).ToList();

            var dto = _mapper.Map<List<DonGiaDTO>>(gias);

            IndexViewModel<DonGiaDTO> returnList = PaginationServices<DonGiaDTO>.PaginationGia(dto, page, ItemPerPage, pageCount, FromDate, ToDate, ApDung);

            return View("~/Views/Admin/Gia/Index.cshtml", returnList);
        }

        [HttpGet("{id?}/price/add")]
        public async Task<IActionResult> Add(int id)
        {
            var lk = await _lkRepo.getById(id);

            if (lk == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            DonGiaDTO gia = new DonGiaDTO();
            var lkDTO = _mapper.Map<LinhKienDTO>(lk);
            gia.LinhKien = lkDTO;
            return View("~/Views/Admin/Gia/Add.cshtml", gia);
        }

        [HttpPost("{id?}/price/add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(int id, [FromForm] DonGiaDTO dto)
        {
            var lk = await _lkRepo.getById(id);

            ViewBag.TenLK = lk.TenLK;

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Gia/Add.cshtml", dto);
            }


            var gia = _mapper.Map<DonGia>(dto);
            gia.LinhKien = lk;
            gia.ApDung = false;

            await _giaRepo.Add(gia);
            return Redirect(Url.Action("Index", "Gia", new { id = id }));
        }

        [HttpGet("{id?}/price/{idPrice?}/edit")]
        public async Task<IActionResult> Edit(int id, int idPrice)
        {
            var gia = await _giaRepo.getById(idPrice);

            if (gia == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            var dto = gia.editMap();

            ViewBag.TenLK = gia.LinhKien.TenLK;

            return View("~/Views/Admin/Gia/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/price/{idPrice?}/edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, int idPrice, [FromForm] GiaEditViewModel dto)
        {
            var gia = await _giaRepo.getById(idPrice);

            ViewBag.TenLK = gia.LinhKien.TenLK;


            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Gia/Edit.cshtml", dto);
            }

            if (dto.ApDung == "0")
            {
                DateTime now = DateTime.Now.Date;
                if (dto.Ngay > now)
                {
                    ModelState.AddModelError("Ngay", "Ngày có thể áp dụng giá này chưa đến");
                    return View("~/Views/Admin/Gia/Edit.cshtml", dto);
                }
            }


            gia.Ngay = dto.Ngay;
            gia.DonGiaBan = dto.DonGiaBan;
            gia.GiamGia = dto.GiamGia;

            if (dto.ApDung == "0")
            {
                gia.ApDung = true;
            }
            else
            {
                gia.ApDung = false;
            }

            await _giaRepo.Update(gia);

            return Redirect(Url.Action("Index", "Gia", new { id = id }));
        }

        [HttpPost("{id?}/price/{idPrice?}/delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Delete(int id, int idPrice)
        {
            var gia = await _giaRepo.getById(idPrice);

            if (gia == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _giaRepo.Delete(gia);
            return Redirect(Url.Action("Index", "Gia", new { id = id }));
        }

    }
}