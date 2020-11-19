using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers
{
    public class LinhKienController : Controller
    {
        private readonly ILinhKienRepository _linhkienRepo;
        private readonly IMapper mapper;
        public LinhKienController(
                                    ILinhKienRepository linhkienRepo,
                                    IMapper mapper
                                 )
        {
            _linhkienRepo = linhkienRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LinhKienDTO>> GetAll()
        {
            var list = await _linhkienRepo.getAll();
            List<LinhKienDTO> result = new List<LinhKienDTO>();
            foreach (LinhKien item in list)
            {
                var dto = mapper.Map<LinhKienDTO>(item);
                result.Add(dto);
            }
            return result;
        }
    }
}
