using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class IndexViewModel<T> where T : class
    {
        public List<T> Entities { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public string searchString { get; set; }
        public string role { get; set; }

    }
}
