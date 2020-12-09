using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using Application.ViewModels;
using GearMVC.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GearMVC.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Nhân viên, Admin, Quản lý")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILinhKienRepository _linhKienRepository;
        private readonly ILoaiLinhKienRepository _llkRepository;
        private readonly INhaCungCapRepository _nccRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly int itemPerPage = 10;

        public ProductController(IMapper mapper, ILinhKienRepository linhKienRepository, ILoaiLinhKienRepository llkRepository, INhaCungCapRepository nccRepository, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _linhKienRepository = linhKienRepository;
            _llkRepository = llkRepository;
            _nccRepository = nccRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        /*
            searchString: Những kí tự muốn search
            searchCategory: id Loại Linh Kiện của các sản phẩm muốn lấy ra
            searchManu: id Nhà Cung Cấp của các sản phẩm muốn lấy ra
            page: trang hiện tại
         */
        public async Task<IActionResult> Index(string searchString = "", int searchCategory = 0, int searchManu = 0, int page = 1)
        {
            if (searchString == null) searchString = "";

            //Get All LinhKien with search
            var linhkiens = await _linhKienRepository.Filter(searchString, searchCategory, searchManu);
            double count = linhkiens.Count();
            int pageCount = (int)Math.Ceiling(count / itemPerPage);
            var LKPagination = linhkiens.Skip((page - 1) * itemPerPage).Take(itemPerPage);

            var dtos = _mapper.Map<List<LinhKienDTO>>(LKPagination);
            foreach (var dto in dtos)
            {
                var hinh = dto.Hinh.Split(',')[0];
                dto.Hinh = hinh;
            }
            //pagination
            var pagination = PaginationServices<LinhKienDTO>.PaginationLinhKien(dtos, page, itemPerPage, pageCount, searchString, searchCategory, searchManu);

            //Get All Category
            var categorys = await _llkRepository.getAll();
            var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
            ViewBag.Category = categoryDTO;

            //Get All Manufactuer
            var manufactuers = await _nccRepository.getAll();
            var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
            ViewBag.Manu = manuDTO;


            return View("~/Views/Admin/Product/Index.cshtml", pagination);
        }

        [HttpGet("Add")]
        public async Task<IActionResult> Add()
        {
            ProductAddViewModel dto = new ProductAddViewModel();

            //Get All Category
            var categorys = await _llkRepository.getAll();
            var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
            ViewBag.Category = categoryDTO;

            //Get All Manufactuer
            var manufactuers = await _nccRepository.getAll();
            var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
            ViewBag.Manu = manuDTO;

            return View("~/Views/Admin/Product/Add.cshtml", dto);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost([FromForm] ProductAddViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                //Get All Category
                var categorys = await _llkRepository.getAll();
                var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
                ViewBag.Category = categoryDTO;

                //Get All Manufactuer
                var manufactuers = await _nccRepository.getAll();
                var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
                ViewBag.Manu = manuDTO;

                return View("~/Views/Admin/Product/Add.cshtml", dto);
            }

            //Lưu Hình vào Server
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string pathS = "";
            Random rnd = new Random();
            pathS = Path.Combine(contentRootPath, "images");
            pathS = Path.Combine(pathS, "products");
            string Hinh = "";
            foreach (var formFile in dto.files)
            {
                if (formFile.Length > 0)
                {
                    try
                    {
                        string fileName = dto.MaLK + rnd.Next(1, 100000) + Path.GetExtension(formFile.FileName);
                        string _path = Path.Combine(contentRootPath, "wwwroot\\images");
                        _path = Path.Combine(_path, "products");
                        _path = Path.Combine(_path, fileName);
                        using (var fileStream = new FileStream(_path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileStream);
                        }
                        Hinh += fileName + ",";
                    }
                    catch
                    {
                        //Get All Category
                        var categorys = await _llkRepository.getAll();
                        var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
                        ViewBag.Category = categoryDTO;

                        //Get All Manufactuer
                        var manufactuers = await _nccRepository.getAll();
                        var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
                        ViewBag.Manu = manuDTO;
                        ModelState.AddModelError("Hinh", "Upload hình không thành công");
                        return View("~/Views/Admin/Product/Add.cshtml", dto);
                    }
                }
            }
            Hinh = Hinh.Remove(Hinh.Length - 1);

            //Create Entity
            LinhKien lk = new LinhKien();
            lk.TenLK = dto.TenLK;
            lk.MaLK = dto.MaLK;
            lk.MoTa = dto.MoTa;
            lk.TGBH = dto.TGBH;
            lk.SLTonKho = dto.SLTonKho;

            DonGia donGia = new DonGia();
            donGia.DonGiaBan = (decimal)dto.Gia;
            donGia.GiamGia = dto.GiamGia;
            donGia.ApDung = true;
            donGia.Ngay = DateTime.Now.Date;

            List<DonGia> donGias = new List<DonGia>();
            donGias.Add(donGia);
            lk.DonGias = donGias;

            var loaillk = await _llkRepository.getById(dto.Loai);
            var ncc = await _nccRepository.getById(dto.NCC);
            lk.Loai = loaillk;
            lk.NCC = ncc;
            lk.Hinh = Hinh;

            await _linhKienRepository.Add(lk);

            return Redirect("/admin/product");
        }

        [HttpGet("{id?}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var linhkien = await _linhKienRepository.getById(id);


            if (linhkien == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            LinhKienDTO dto = _mapper.Map<LinhKienDTO>(linhkien);

            //Get All Category
            var categorys = await _llkRepository.getAll();
            var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
            ViewBag.Category = categoryDTO;

            //Get All Manufactuer
            var manufactuers = await _nccRepository.getAll();
            var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
            ViewBag.Manu = manuDTO;

            var images = dto.Hinh.Split(",");
            ViewBag.Hinh = images;

            return View("~/Views/Admin/Product/Edit.cshtml", dto);
        }

        [HttpPost("{id?}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [FromForm] List<IFormFile> files, [FromForm] LinhKienDTO dto, [FromForm] List<string> oldFiles)
        {
            if (oldFiles.Count == 0 && (files == null || files.Count == 0))
            {
                //Get All Category
                var categorys = await _llkRepository.getAll();
                var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
                ViewBag.Category = categoryDTO;

                //Get All Manufactuer
                var manufactuers = await _nccRepository.getAll();
                var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
                ViewBag.Manu = manuDTO;

                var imagesE = dto.Hinh.Split(",");
                ViewBag.Hinh = imagesE;
                ModelState.AddModelError("Hinh", "Thêm ít nhất một hình");

                return View("~/Views/Admin/Product/Edit.cshtml", dto);
            }

            if (!ModelState.IsValid)
            {
                //Get All Category
                var categorys = await _llkRepository.getAll();
                var categoryDTO = _mapper.Map<List<LoaiLinhKienDTO>>(categorys);
                ViewBag.Category = categoryDTO;

                //Get All Manufactuer
                var manufactuers = await _nccRepository.getAll();
                var manuDTO = _mapper.Map<List<NhaCungCapDTO>>(manufactuers);
                ViewBag.Manu = manuDTO;

                var imagesE = dto.Hinh.Split(",");
                ViewBag.Hinh = imagesE;

                return View("~/Views/Admin/Product/Edit.cshtml", dto);
            }

            var lk = await _linhKienRepository.getById(id);
            var images = lk.Hinh.Split(",");
            string webRootPath = _webHostEnvironment.WebRootPath;
            string Hinh = "";
            // Xóa những hình bị yêu cầu xóa
            foreach (var image in images)
            {
                var flg = false;
                foreach (var oldFile in oldFiles)
                {
                    if (oldFile == image)
                    {
                        flg = true;
                        Hinh += oldFile + ",";
                    }
                }
                if (flg == false)
                {
                    var fullPath = webRootPath + "/images/products/" + image;
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
            }

            //Lưu Hình vào Server
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string pathS = "";
            Random rnd = new Random();
            pathS = Path.Combine(contentRootPath, "images");
            pathS = Path.Combine(pathS, "products");

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    try
                    {
                        string fileName = dto.MaLK + rnd.Next(1, 100000) + Path.GetExtension(formFile.FileName);
                        string _path = Path.Combine(contentRootPath, "wwwroot\\images");
                        _path = Path.Combine(_path, "products");
                        _path = Path.Combine(_path, fileName);
                        using (var fileStream = new FileStream(_path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileStream);
                        }
                        Hinh += fileName + ",";
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            Hinh = Hinh.Remove(Hinh.Length - 1);

            //Sửa dữ liệu
            lk.TenLK = dto.TenLK;
            lk.MaLK = dto.MaLK;
            lk.MoTa = dto.MoTa;
            lk.TGBH = dto.TGBH;
            lk.SLTonKho = dto.SLTonKho;

            var loaillk = await _llkRepository.getById(dto.LoaiId);
            var ncc = await _nccRepository.getById(dto.NCCId);
            lk.Loai = loaillk;
            lk.NCC = ncc;
            lk.Hinh = Hinh;
            lk.NgayCapNhat = DateTime.Now;
            await _linhKienRepository.Update(lk);

            return Redirect("/admin/product");
        }

        [HttpPost("{id?}/Delete")]
        [Authorize(Roles = "Admin, Quản lý")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var linhkien = await _linhKienRepository.getById(id);

            if (linhkien == null)
            {
                return View("~/Views/Error/404.cshtml");
            }

            await _linhKienRepository.Delete(linhkien);
            return Redirect("/admin/product");
        }

    }
}
