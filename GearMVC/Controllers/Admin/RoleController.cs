using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Mapping;
using Application.ViewModels;
using AutoMapper;
using Domain.IRepository;
using GearMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(string searchString = "", int page = 1)
        {
            var list = await _roleRepository.Filter(searchString);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);

            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage);
            var dto = _mapper.Map<List<LoaiTKDTO>>(list);

            IndexViewModel<LoaiTKDTO> returnList = PaginationServices<LoaiTKDTO>.Pagination(dto, page, ItemPerPage, pageCount, searchString);

            return View("~/Views/Admin/Role/Index.cshtml", returnList);
        }
        [HttpGet("Add")]
        [Authorize(Roles = "Admin, Quản lý")]
        public IActionResult Add()
        {
            LoaiTKDTO dto = new LoaiTKDTO();
            return View("~/Views/Admin/Role/Add.cshtml", dto);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(LoaiTKDTO dto)
        {
            var message = "";

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Role/Add.cshtml", dto);
            }

            message = "Tạo thành công";
            ViewBag.Message = message;
            var loaiTK = dto.AddMap();
            await _roleRepository.Add(loaiTK);
            return View("~/Views/Admin/Role/Add.cshtml", dto);

        }

        [HttpGet("{id?}/Edit")]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Edit(string id)
        {
            var loaiTK = await _roleRepository.getById(id);
            if (loaiTK == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            var dto = _mapper.Map<LoaiTKDTO>(loaiTK);
            return View("~/Views/Admin/Role/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string id, LoaiTKDTO dto)
        {
            var message = "";

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Role/Edit.cshtml", dto);
            }

            var loaiTK = await _roleRepository.getById(id);

            //Update Du Lieu
            loaiTK = dto.EditMap(loaiTK);
            await _roleRepository.Update(loaiTK);
            message = "Sửa thành công";
            ViewBag.Message = message;
            return View("~/Views/Admin/Role/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Delete")]
        [Authorize(Roles = "Admin, Quản lý")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var loaiTK = await _roleRepository.getById(id);

            if (loaiTK == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _roleRepository.Delete(loaiTK);
            return Redirect("/admin/role");
        }
    }
}
