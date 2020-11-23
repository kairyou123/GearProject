using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public int isDelete { get; set; }

    }
}