using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GearMVC.Models;
using Domain.IRepository;

namespace GearMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinhKienRepository _linhkienRepo;

        public HomeController(ILogger<HomeController> logger,
                              ILinhKienRepository linhkienRepo
                )
        {
            _logger = logger;
            _linhkienRepo = linhkienRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _linhkienRepo.getAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
