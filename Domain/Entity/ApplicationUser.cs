using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Mauser {get;set;}
        public string DiaChi {get;set;}
        public string GioiTinh {get;set;}
        public string CMND {get;set;}
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgaySinh { get; set; }
        public ICollection<HoaDon> HoaDons{ get; set; }
        public ICollection<GioHang> GioHang { get; set; }
        public int isDelete { get; set; }
    }
}