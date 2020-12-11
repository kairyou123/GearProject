using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class GioHangRepository : IGioHangRepository
    {
        private GearContext _context;

        public GioHangRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GioHang>> getAll()
        {
            var result = await _context.GioHangs.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<GioHang>> getByUser(string id)
        {
            var result = await _context.GioHangs.Where(i => i.UserId == id).Include(i => i.LinhKien).ThenInclude(i => i.DonGias).ToListAsync();

            result.ForEach(i => i.LinhKien.DonGias = i.LinhKien.DonGias.Where(dongia => dongia.ApDung).ToList());
            return result;
        }
        public async Task<GioHang> getById(string userid, int linhkienid)
        {
            var result = await _context.GioHangs.Where(i => i.UserId == userid && i.LinhKienId == linhkienid).FirstOrDefaultAsync();
            return result;
        }
        public async Task<int> getCartsNum(string id)
        {
            var result = await _context.GioHangs.Where(i => i.UserId == id).ToListAsync();
            return result.Count;
        }
        public async Task Add(GioHang item)
        {
           
            _context.GioHangs.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(GioHang item)
        {
            _context.GioHangs.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(GioHang item)
        {
            _context.GioHangs.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<GioHang> items)
        {
            _context.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
