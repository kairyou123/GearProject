using Application.DTO;
using Domain.Entity;
using System;
using Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GearMVC.Services
{
    public static class PaginationServices<T> where T : class
    {
        public static IndexViewModel<T> Pagination(List<T> list, int page, int itemPerPage, int pageCount, string searchString, string role = "")
        {
            return new IndexViewModel<T>
            {
                Entities = new List<T>(list),
                CurrentPage = page,
                PageCount = pageCount,
                searchString = searchString,
                role = role
            };
        }

        public static ProductIndexViewModel PaginationLinhKien(List<LinhKienDTO> list, int page, int itemPerPage, int pageCount, string searchString, int searchCategory, int searchManu)
        {
            return new ProductIndexViewModel
            {
                Entities = new List<LinhKienDTO>(list),
                CurrentPage = page,
                PageCount = pageCount,
                searchString = searchString,
                searchCategory = searchCategory,
                searchManu = searchManu
            };
        }

        public static IndexViewModel<DonGiaDTO> PaginationGia(List<DonGiaDTO> list, int page, int itemPerPage, int pageCount, DateTime FromDate, DateTime ToDate, string ApDung)
        {
            return new IndexViewModel<DonGiaDTO>
            {
                Entities = new List<DonGiaDTO>(list),
                CurrentPage = page,
                PageCount = pageCount,
                FromDate = FromDate,
                ToDate = ToDate,
                ApDung = ApDung
            };
        }

        public static IndexViewModel<HoaDonDTO> PaginationHoaDon(List<HoaDonDTO> list, int page, int itemPerPage,
                                                                int pageCount, string searchString, string tinhTrang, string orderBy,
                                                                DateTime FromDate, DateTime ToDate)
        {
            return new IndexViewModel<HoaDonDTO>
            {
                Entities = new List<HoaDonDTO>(list),
                CurrentPage = page,
                PageCount = pageCount,
                FromDate = FromDate,
                ToDate = ToDate,
                TinhTrang = tinhTrang,
                searchString = searchString,
                orderBy = orderBy
            };
        }


    }
}
