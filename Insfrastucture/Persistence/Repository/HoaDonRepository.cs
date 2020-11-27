using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
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
            var result = await _context.HoaDons.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<HoaDon>> getByUser(string id)
        {
            var result = await _context.HoaDons.Where(i => i.UserId == id).ToListAsync();
            return result;
        }
        public async Task<HoaDon> getById(int id)
        {
            var result = await _context.HoaDons.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(HoaDon item)
        {
            _context.HoaDons.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(HoaDon item)
        {
            _context.HoaDons.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(HoaDon item)
        {
            _context.HoaDons.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
