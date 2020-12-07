using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using AutoMapper.Configuration.Conventions;
using Application.Mapping;
using GearMVC.Services;
using Application.ViewModels;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;

namespace GearMVC.Controllers
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class CategoryController : Controller
    {
        private readonly ILoaiLinhKienRepository _loaiLinhKienRepo;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;
        public CategoryController(ILoaiLinhKienRepository loaiLinhKienrRepo, IMapper mapper)
        {
            _loaiLinhKienRepo = loaiLinhKienrRepo;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index(string searchString = "", int page = 1)
        {
            if (searchString == null) searchString = "";

            IEnumerable<LoaiLinhKien> list = await _loaiLinhKienRepo.Filter(searchString);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);


            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            List<LoaiLinhKienDTO> loaiLinhKiens = _mapper.Map<List<LoaiLinhKienDTO>>(list);


            IndexViewModel<LoaiLinhKienDTO> returnList = PaginationServices<LoaiLinhKienDTO>.Pagination(loaiLinhKiens, page, ItemPerPage, pageCount, searchString);

            return View("~/Views/Admin/Category/Index.cshtml", returnList);
        }
        [HttpGet("Add")]
        [Authorize(Roles = "Admin, Quản lý")]
        public IActionResult Add()
        {
            LoaiLinhKienDTO dto = new LoaiLinhKienDTO();
            ViewBag.Title = "Thêm Chủng Loại";
            return View("~/Views/Admin/Category/Add.cshtml", dto);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(LoaiLinhKienDTO loaiLinhKienDTO)
        {
            var message = "";
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Category/Add.cshtml", loaiLinhKienDTO);
            }


            message = "Tạo thành công";
            ViewBag.Message = message;
            ViewBag.Title = "Thêm Chủng Loại";
            LoaiLinhKien loaiLinhKien = _mapper.Map<LoaiLinhKien>(loaiLinhKienDTO);
            await _loaiLinhKienRepo.Add(loaiLinhKien);
            return View("~/Views/Admin/Category/Add.cshtml", loaiLinhKienDTO);

        }
        [HttpGet("{id?}/Edit")]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = "Sửa Chủng Loại";
            LoaiLinhKien loaiLinhKien = await _loaiLinhKienRepo.getById(id);
            if (loaiLinhKien == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            LoaiLinhKienDTO dto = _mapper.Map<LoaiLinhKienDTO>(loaiLinhKien);
            return View("~/Views/Admin/Category/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, LoaiLinhKienDTO dto)
        {
            ViewBag.Title = "Sửa Chủng Loại";
            var message = "";
            LoaiLinhKien loaiLinhKien = await _loaiLinhKienRepo.getById(id);

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Category/Edit.cshtml", dto);
            }

            //Update Du Lieu
            loaiLinhKien = dto.LoaiLinhKienMap(loaiLinhKien);
            await _loaiLinhKienRepo.Update(loaiLinhKien);
            message = "Sửa thành công";
            ViewBag.Message = message;
            return View("~/Views/Admin/Category/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Delete")]
        [Authorize(Roles = "Admin, Quản lý")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var loaiLinhKien = await _loaiLinhKienRepo.getById(id);
            if (loaiLinhKien == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _loaiLinhKienRepo.Delete(loaiLinhKien);
            return Redirect("/admin/category");
        }
    }
}