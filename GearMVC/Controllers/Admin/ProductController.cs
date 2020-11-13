using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using GearMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILinhKienRepository _linhKienRepository;
        private readonly ILoaiLinhKienRepository  _llkRepository;
        private readonly INhaCungCapRepository _nccRepository;
        private readonly int itemPerPage = 10;

        public ProductController(IMapper mapper, ILinhKienRepository linhKienRepository, ILoaiLinhKienRepository llkRepository, INhaCungCapRepository nccRepository)
        {
            _mapper = mapper;
            _linhKienRepository = linhKienRepository;
            _llkRepository = llkRepository;
            _nccRepository = nccRepository;
        }

        /*
            searchString: Những kí tự muốn search
            searchCategory: id Loại Linh Kiện của các sản phẩm muốn lấy ra
            searchManu: id Nhà Cung Cấp của các sản phẩm muốn lấy ra
            page: trang hiện tại
         */
        public async Task<IActionResult> Index(string searchString="", int searchCategory=0, int searchManu=0, int page=1)
        {
            //Get All LinhKien with search
            var linhkiens = await _linhKienRepository.Filter(searchString,searchCategory,searchManu);
            double count = linhkiens.Count();
            int pageCount = (int)Math.Ceiling(count / itemPerPage);
            var LKPagination = linhkiens.Skip((page - 1) * itemPerPage).Take(itemPerPage);

            var dto = _mapper.Map<List<LinhKienDTO>>(LKPagination);

            //pagination
            var pagination = PaginationServices<LinhKienDTO>.PaginationLinhKien(dto, page, itemPerPage, pageCount, searchString, searchCategory, searchManu);

            //Get All Category
            var categorys = await _llkRepository.getAll();
            ViewBag.Category = categorys;

            //Get All Manufactuer
            var manufactuers = await _nccRepository.getAll();
            ViewBag.Manu = manufactuers;

            return View("~/Views/Admin/Product/Index.cshtml",pagination);
        }
    }
}
