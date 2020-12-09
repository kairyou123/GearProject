using System.Security.Cryptography;
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
using Microsoft.AspNetCore.Identity;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/user")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class UserAdminController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly int ItemPerPage = 10;

        public UserAdminController(IUserRepository userRepo, IMapper mapper, IRoleRepository roleRepo, UserManager<ApplicationUser> userManager)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _roleRepo = roleRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string role, int page = 1)
        {
            if (searchString == null) searchString = "";

            var list = await _userRepo.Filter(searchString, role);
            double count = list.Count();
            double i = (double)(count / ItemPerPage);
            var pageCount = (int)Math.Ceiling(i);

            list = list.Skip((page - 1) * ItemPerPage).Take(ItemPerPage);
            List<UserDTO> dtos = new List<UserDTO>();
            foreach (ApplicationUser user in list)
            {
                var dto = user.MapDTO();
                dtos.Add(dto);
            }
            var roles = await _roleRepo.getAll();
            ViewBag.Roles = roles;
            IndexViewModel<UserDTO> returnList = PaginationServices<UserDTO>.Pagination(dtos, page, ItemPerPage, pageCount, searchString, role);


            return View("~/Views/Admin/User/Index.cshtml", returnList);
        }

        [HttpGet("add")]
        [Authorize(Roles = "Admin, Quản lý")]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleRepo.getAll();
            ViewBag.Roles = roles;
            RegisterViewModel model = new RegisterViewModel();
            return View("~/Views/Admin/User/Add.cshtml", model);
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(RegisterViewModel model, string Role)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _roleRepo.getAll();
                ViewBag.Roles = roles;
                return View("~/Views/Admin/User/Add.cshtml", model);
            }

            if (model.Password != model.PasswordConfirm)
            {
                var roles = await _roleRepo.getAll();
                ViewBag.Roles = roles;
                ModelState.AddModelError("Password", "Mật khẩu không trùng khớp");
                return View("~/Views/Admin/User/Add.cshtml", model);
            }

            var userExisted = await _userRepo.getByEmail(model.Email);

            if (userExisted != null)
            {
                var roles = await _roleRepo.getAll();
                ViewBag.Roles = roles;
                ModelState.AddModelError("Email", "Email đã có người sử dụng");
                return View("~/Views/Admin/User/Add.cshtml", model);
            }

            var user = model.MapToUser();
            await _userRepo.Add(user, model.Password, Role);
            return Redirect("/admin/user");
        }

        [HttpGet("{id?}/edit")]
        public async Task<IActionResult> Edit(string Id)
        {
            if (User.IsInRole("Nhân viên"))
            {
                var idCurrent = _userManager.GetUserId(User);
                if (idCurrent != Id)
                {
                    return View("~/Views/Admin/Error.cshtml");
                }
            }

            var roles = await _roleRepo.getAll();
            ViewBag.Roles = roles;

            ApplicationUser user = await _userRepo.getById(Id);

            if (user == null)
            {
                return View("~/Views/Error/404.cshtml");
            }
            var model = user.MapToEditViewModel();

            ViewBag.CurrentRole = user.UserRoles.FirstOrDefault().Role.Name;

            return View("~/Views/Admin/User/Edit.cshtml", model);
        }

        [HttpPost("{id?}/edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(EditUserViewModel model, string Role, string Id)
        {
            var roles = await _roleRepo.getAll();
            ViewBag.Roles = roles;
            ViewBag.CurrentRole = Role;

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/User/Edit.cshtml", model);
            }

            if (model.Password != null && model.Password != "")
            {
                if (model.Password.Length < 5)
                {
                    ModelState.AddModelError("Password", "Mật khẩu ít nhất 5 ký tự");
                    return View("~/Views/Admin/User/Edit.cshtml", model);
                }
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError("Password", "Mật khẩu thay đổi không trùng khớp");
                    return View("~/Views/Admin/User/Edit.cshtml", model);
                }
            }

            var user = await _userRepo.getById(Id);

            user = model.EditMapToUser(user);

            await _userRepo.Update(user, Role, model.Password);

            return Redirect("/admin/user");
        }

        [HttpPost("{id?}/delete")]
        [Authorize(Roles = "Admin, Quản lý")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userRepo.getById(Id);

            if (user == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _userRepo.Delete(user);

            return Redirect("/admin/user");
        }
    }
}
