using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.ViewModels;
using Domain.IRepository;
using AutoMapper;
using Application.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Domain.Entity;
using Application.Services;
namespace GearMVC.Controllers
{
    [Route("")]
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
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var list = await _linhkienRepo.getNewItems();
            var  result = new List<List<LinhKienDTO>>();
            List<LinhKienDTO> result_item = new List<LinhKienDTO>();
            foreach(LinhKien item in list)
            {
                //item.DonGias = item.DonGias.Where(i => i.ApDung).ToList();
                var dto = mapper.Map<LinhKienDTO>(item);
                result_item.Add(dto);
            }
            result.Add(result_item);


            list = await _linhkienRepo.getTopSelling();
            result_item = new List<LinhKienDTO>();
            foreach (LinhKien item in list)
            {
                var dto = mapper.Map<LinhKienDTO>(item);
                result_item.Add(dto);
            }
            result.Add(result_item);
            return View(result);
        }
        
    }
}
