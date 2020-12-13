using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private GearContext _context;

        public HoaDonRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HoaDon>> getAll()
        {
            var result = await _context.HoaDons.Include(i => i.User).Include(i => i.ChiTietHDs).ThenInclude(i => i.LinhKien).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<HoaDon>> getByUser(string id)
        {
            var result = await _context.HoaDons.Where(i => i.UserId == id)
                                                .Include(i => i.User)
                                                .Include(i => i.ChiTietHDs).ThenInclude(i => i.LinhKien)
                                                .OrderByDescending(i => i.NgayLapHD)
                                                .ToListAsync();
            return result;
        }
        public async Task<HoaDon> getById(int id)
        {
            var result = await _context.HoaDons.Where(i => i.Id == id)
                                               .Include(i => i.User)
                                               .Include(i => i.ChiTietHDs).ThenInclude(i => i.LinhKien)
                                               .FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(HoaDon item)
        {
            item.MaHD = await GenerateCode();
            foreach (var linhkien in item.ChiTietHDs)
                linhkien.LinhKien.SLTonKho = linhkien.LinhKien.SLTonKho - (int)linhkien.SoLuongBan;
            _context.HoaDons.Add(item);
            await _context.SaveChangesAsync();
            
        }
        public async Task Update(HoaDon item)
        {
           
        if(item.TinhTrang == Status.DaHuy)
            {      
                foreach (var linhkien in item.ChiTietHDs)
                {
                    linhkien.LinhKien.SLTonKho = linhkien.LinhKien.SLTonKho + (int)linhkien.SoLuongBan;
                }  
            }
        else if(item.TinhTrang == Status.DaGiao)
            {
                item.NgayGiao = DateTime.Now;
                foreach (var linhkien in item.ChiTietHDs)
                {
                    linhkien.LinhKien.DaBan = linhkien.LinhKien.DaBan + (int)linhkien.SoLuongBan;
                }
            }
             
            _context.HoaDons.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(HoaDon item)
        {
            _context.HoaDons.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HoaDon>> Filter(string searchString = "", string orderBy = "", string tinhTrang = "", DateTime fromDate = default, DateTime toDate = default)
        {
            var query = _context.HoaDons.AsQueryable();

            if (searchString != "")
            {
                query = query.Where(i => i.MaHD.Contains(searchString));
            }

            if (tinhTrang != "")
            {
                if (tinhTrang == Status.ChoXacNhan)
                {
                    query = query.Where(i => i.TinhTrang == Status.ChoXacNhan);
                }
                else if (tinhTrang == Status.DaXacNhan)
                {
                    query = query.Where(i => i.TinhTrang == Status.DaXacNhan);
                }
                else if (tinhTrang == Status.DangDongGoi)
                {
                    query = query.Where(i => i.TinhTrang == Status.DangDongGoi);
                }
                else if (tinhTrang == Status.DangVanChuyen)
                {
                    query = query.Where(i => i.TinhTrang == Status.DangVanChuyen);
                }
                else if (tinhTrang == Status.DaGiao)
                {
                    query = query.Where(i => i.TinhTrang == Status.DaGiao);
                }
                else if (tinhTrang == Status.DaHuy)
                {
                    query = query.Where(i => i.TinhTrang == Status.DaHuy);
                }
            }

            if (fromDate != default && toDate != default)
            {
                query = query.Where(i => i.NgayLapHD >= fromDate && i.NgayLapHD <= toDate);
            }

            if (orderBy == "")
            {
                query = query.OrderByDescending(i => i.NgayLapHD);
            }

            query = query.Include(i => i.User).Include(i => i.ChiTietHDs).ThenInclude(i => i.LinhKien);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<HoaDon>> getOrderThreeMonthAgoAndNow()
        {
            var now = DateTime.Now;
            var month = now.Month;
            var oneMonthAgo = now.Month - 1;
            var twoMonthsAgo = now.Month - 2;
            var threeMonthAgo = now.Month - 3;

            var result = await _context.HoaDons.Where(i => (i.NgayLapHD.Month == month
                                                     || i.NgayLapHD.Month == oneMonthAgo || i.NgayLapHD.Month == twoMonthsAgo || i.NgayLapHD.Month == threeMonthAgo) && i.TinhTrang == Status.DaGiao)
                                               .ToListAsync();

            return result;
        }

        public async Task<string> GenerateCode()
        {
            var item = await _context.HoaDons.OrderByDescending(i => i.MaHD).FirstOrDefaultAsync();
            var str = "HD";
            if (item == null)
            {
                str += "00000000001";
            }
            else
            {
                var range = 11;
                var num = decimal.Parse(item.MaHD.Split("HD")[1]) + 1;
                var loop = range - num.ToString().Length;
                for (var i = 0; i < loop; i++)
                {
                    str += "0";
                }
                str += num;
            }

            return str;
        }
    }



    public static class Status
    {
        public const string ChoXacNhan = "Chờ xác nhận";
        public const string DaXacNhan = "Đã xác nhận";
        public const string DangDongGoi = "Đang đóng gói";
        public const string DangVanChuyen = "Đang vận chuyển";
        public const string DaGiao = "Đã giao hàng";
        public const string DaHuy = "Đã hủy";
    }
}
