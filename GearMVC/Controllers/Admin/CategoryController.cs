using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers
{
    [Route("admin/[controller]")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Category/Index.cshtml");
        }
    }
}