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
    [Route("admin/user")]
    [Authorize(Roles = "Admin")]
    public class UserAdminController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;

        public UserAdminController(IUserRepository userRepo, IMapper mapper, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string role,int page = 1)
        {
            if (searchString == null) searchString = "";

            var list = await _userRepo.Filter(searchString, role);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);

            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage);
            List<UserDTO> dtos = new List<UserDTO>();
            foreach(ApplicationUser user in list)
            {
                var dto = user.MapDTO();
                dtos.Add(dto);
            }
            var roles = await _roleRepo.getAll();
            ViewBag.Roles = roles;
            IndexViewModel<UserDTO> returnList = PaginationServices<UserDTO>.Pagination(dtos, page, ItemPerPage, pageCount, searchString, role);

            
                return View("~/Views/Admin/User/Index.cshtml", returnList);
        }
    }
}
