using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<GioHang> getById(int id)
        {
            var result = await _context.GioHangs.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
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
    }
}
