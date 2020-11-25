using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers
{
    public class ErrorController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ErrorController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet("/access-denied")]
        public IActionResult AccessDenied()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                if (!HttpContext.User.IsInRole("Khách hàng"))
                {
                    return RedirectToAction("Error", new { statusCode = 401 });
                }
            }

            return RedirectToAction("Error", new { statusCode = 404 });
        }

        [HttpGet("/error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 401)
                {
                    if (_signInManager.IsSignedIn(HttpContext.User))
                    {
                        if (HttpContext.User.IsInRole("Khách hàng"))
                        {
                            return View("~/Views/Error/404.cshtml");
                        }
                        else
                        {
                            return Redirect("/admin/error");
                        }
                    }

                    if (statusCode.Value == 404)
                    {
                        return View("~/Views/Error/404.cshtml");
                    }

                }
            }
            return View("~/Views/Error/404.cshtml");
        }

        [HttpGet("/admin/error")]
        [Authorize(Roles = "Admin,Quản lý, Nhân viên")]
        public IActionResult AdminError()
        {
            return View("~/Views/Admin/Error.cshtml");
        }
    }

}
