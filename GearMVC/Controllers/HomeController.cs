using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GearMVC.Models;
using Domain.IRepository;
using AutoMapper;
using Application.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Domain.Entity;

namespace GearMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly ILinhKienRepository _linhkienRepo;

        public HomeController(ILogger<HomeController> logger,
                              ILinhKienRepository linhkienRepo,
                              IMapper mapper
                )
        {
            _logger = logger;
            _linhkienRepo = linhkienRepo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _linhkienRepo.getAll();
            List<LinhKienDTO> result = new List<LinhKienDTO>();
            foreach(LinhKien item in list)
            {
                var dto = mapper.Map<LinhKienDTO>(item);
                result.Add(dto);
            }
            return View(result);
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
