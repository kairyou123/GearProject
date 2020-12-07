using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class DashboardController : Controller
    {
        public readonly IHoaDonRepository _hoadonRepo;
        private readonly IMapper _mapper;

        public DashboardController(IHoaDonRepository hoadonRepo, IMapper mapper)
        {
            _hoadonRepo = hoadonRepo;
            _mapper = mapper;
        }

        [HttpGet("getOrderThreeMonth")]
        public async Task<IActionResult> getOrderThreeMonth()
        {
            var list = await _hoadonRepo.getOrderThreeMonthAgoAndNow();

            if (list == null || list.Count() == 0)
            {
                return NotFound();
            }

            var dtoList = _mapper.Map<List<HoaDonDTO>>(list);

            var returnList = JsonConvert.SerializeObject(dtoList, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Ok(returnList);
        }


    }
}