using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Microsoft.AspNetCore.Identity;
using Domain.Entity;
using Application.ViewModels;

namespace GearMVC.Controllers.User
{
    [Route("dang-ky")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            RegisterViewModel viewModel = new RegisterViewModel();
            return View("Register", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(RegisterViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Register", viewModel);
            }

            if(viewModel.Password != viewModel.PasswordConfirm)
            {
                ModelState.AddModelError("Password", "Mật mã không trùng khớp");
                return View("Register", viewModel);
            }

            var emailUsed = await _userManager.FindByEmailAsync(viewModel.Email);

            if(emailUsed != null)
            {
                ModelState.AddModelError("Email", "Email đã có người sử dụng");
                return View("Register", viewModel);
            }

            var user = new ApplicationUser
            {
                UserName= viewModel.Email,
                Email = viewModel.Email,
                HoTen = viewModel.HoTen,
                PhoneNumber = viewModel.PhoneNumber,
                GioiTinh = viewModel.GioiTinh,
                CMND = viewModel.CMND,
                DiaChi = viewModel.DiaChi,
                isDelete = 0
            };

            
            var result =  await _userManager.CreateAsync(user, viewModel.Password);

            if(result.Succeeded)
            {
                var roleExisted = await _roleManager.RoleExistsAsync("Khách hàng");
                if(!roleExisted)
                {
                    var role = new IdentityRole
                    {
                        Name = "Khách hàng"
                    };
                    await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(user, "Khách hàng");
            }
            else
            {
                ModelState.AddModelError("Email","Đăng kí không thành công");
                return View("Register", viewModel);
            }

            ViewBag.Email = user.Email;
            return View("RegisterComplete");
        }
    }
}
