using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Application.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<LinhKienDTO> Entities { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public string searchString { get; set; }
        public int searchCategory { get; set; }
        public int searchManu { get; set; }
    }
}
