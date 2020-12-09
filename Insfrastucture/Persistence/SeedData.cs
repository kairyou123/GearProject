using Domain.Entity;
using Insfrastucture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastucture.Persistence
{
    public class SeedData
    {
        public static async Task Initialize(GearContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any()) return;

            context.Roles.AddRange(new List<ApplicationRole>{
                new ApplicationRole
                {
                    Name = "Khách hàng",
                    NormalizedName = "KHÁCH HÀNG"
                },
                new ApplicationRole
                {
                    Name = "Quản lý",
                    NormalizedName = "QUẢN LÝ"
                },
                new ApplicationRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
            });

            ApplicationUser user = new ApplicationUser
            {
                HoTen = "Alice",
                GioiTinh = "Nữ",
                PhoneNumber = "01234567",
                DiaChi = "123 ABC",
                CMND = "123456789",
                Email = "alice@gmail.com",
                UserName = "alice@gmail.com",
                isDelete = 0
            };
            await userManager.CreateAsync(user, "123456");
            await userManager.AddToRoleAsync(user, "Admin");

            context.LoaiLinhKiens.AddRange(new List<LoaiLinhKien>{
                new LoaiLinhKien
                {
                    MaLoai = "00001",
                    Ten = "Bàn phím",
                    isDelete = 0
                },
                new LoaiLinhKien
                {
                    MaLoai = "00002",
                    Ten = "Chuột",
                    isDelete = 0
                },
                new LoaiLinhKien
                {
                    MaLoai = "00003",
                    Ten = "Tai nghe",
                    isDelete = 0
                },
                new LoaiLinhKien
                {
                    MaLoai = "00004",
                    Ten = "Lót chuột",
                    isDelete = 0
                },

            });


            context.NhaCungCaps.AddRange(new List<NhaCungCap>{
                new NhaCungCap
                {
                    MaNCC = "00001",
                    TenNCC = "Razer",
                    isDelete = 0
                },
                new NhaCungCap
                {
                    MaNCC = "00002",
                    TenNCC = "DareU",
                    isDelete = 0
                },
                new NhaCungCap
                {
                    MaNCC = "00003",
                    TenNCC = "Fuhlen",
                    isDelete = 0
                },
                new NhaCungCap
                {
                    MaNCC = "00004",
                    TenNCC = "SteelSeries",
                    isDelete = 0
                },


            });

            context.SaveChanges();
        }
    }
}
