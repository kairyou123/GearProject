
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entity;

namespace Insfrastucture.Context
{
    public class GearContext : DbContext
    {
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public DbSet<CTGiao> CTGiaos { get; set; }
        public DbSet<DonGia> DonGias { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<HoaDonNhapHang> HoaDonNhapHangs { get; set; }
        public DbSet<LinhKien> LinhKiens { get; set; }
        public DbSet<LoaiLinhKien> LoaiLinhKiens { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TonKho> TonKhos { get; set; }
        public GearContext(DbContextOptions<GearContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        

    }
}
