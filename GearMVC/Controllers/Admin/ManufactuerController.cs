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
using Application.ViewModels;
using GearMVC.Services;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;

namespace GearMVC.Controllers
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class ManufactuerController : Controller
    {
        private readonly INhaCungCapRepository _nccRepo;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;
        public ManufactuerController(INhaCungCapRepository nccRepo, IMapper mapper)
        {
            _nccRepo = nccRepo;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(string searchString = "", int page = 1)
        {
            if (searchString == null) searchString = "";

            IEnumerable<NhaCungCap> list = await _nccRepo.Filter(searchString);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);


            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            List<NhaCungCapDTO> nccs = _mapper.Map<List<NhaCungCapDTO>>(list);


            IndexViewModel<NhaCungCapDTO> returnList = PaginationServices<NhaCungCapDTO>.Pagination(nccs, page, ItemPerPage, pageCount, searchString);

            return View("~/Views/Admin/Manufactuer/Index.cshtml", returnList);
        }
        [HttpGet("Add")]
        [Authorize(Roles = "Admin, Quản lý")]
        public IActionResult Add()
        {
            NhaCungCapDTO dto = new NhaCungCapDTO();
            ViewBag.Title = "Thêm Nhà Sản Xuất";
            return View("~/Views/Admin/Manufactuer/Add.cshtml", dto);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(NhaCungCapDTO dto)
        {
            var message = "";
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Manufactuer/Add.cshtml", dto);
            }


            message = "Tạo thành công";
            ViewBag.Message = message;
            ViewBag.Title = "Thêm Chủng Loại";
            NhaCungCap ncc = _mapper.Map<NhaCungCap>(dto);
            await _nccRepo.Add(ncc);
            return View("~/Views/Admin/Manufactuer/Add.cshtml", dto);

        }
        [HttpGet("{id?}/Edit")]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = "Sửa Nhà Sản Xuất";
            NhaCungCap ncc = await _nccRepo.getById(id);
            if (ncc == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            NhaCungCapDTO dto = _mapper.Map<NhaCungCapDTO>(ncc);
            return View("~/Views/Admin/Manufactuer/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, NhaCungCapDTO dto)
        {
            ViewBag.Title = "Sửa Chủng Loại";
            var message = "";
            NhaCungCap ncc = await _nccRepo.getById(id);

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Manufactuer/Edit.cshtml", dto);
            }

            //Update Du Lieu
            ncc = dto.NhaCungCapEditMap(ncc);
            await _nccRepo.Update(ncc);
            message = "Sửa thành công";
            ViewBag.Message = message;
            return View("~/Views/Admin/Manufactuer/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Delete(int id)
        {
            var ncc = await _nccRepo.getById(id);
            if (ncc == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _nccRepo.Delete(ncc);
            return Redirect("/admin/manufactuer");
        }
    }
}