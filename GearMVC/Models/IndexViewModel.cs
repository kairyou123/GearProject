using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearMVC.Models
{
    public class IndexViewModel<T> where T : class
    {
        public List<T> Entities { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public string searchString { get; set; }

    }
}
