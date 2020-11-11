using GearMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GearMVC.Services
{
    public static class PaginationServices<T> where T : class
    {
        public static IndexViewModel<T> Pagination(List<T> list, int page, int itemPerPage, int pageCount,string searchString)
        {
            return  new IndexViewModel<T>
            {
                Entities = new List<T>(list),
                CurrentPage = page,
                PageCount = pageCount,
                searchString = searchString
            };
        }

    }
}
