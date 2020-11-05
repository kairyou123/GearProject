using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class LoaiLinhKienRepository : ILoaiLinhKienRepository
    {
        private GearContext _context;

        public LoaiLinhKienRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoaiLinhKien>> getAll()
        {
            var result = await _context.LoaiLinhKiens.ToListAsync();
            return result;
        }
        public async Task<LoaiLinhKien> getById(int id)
        {
            var result = await _context.LoaiLinhKiens.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(LoaiLinhKien item)
        {
            _context.LoaiLinhKiens.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(LoaiLinhKien item)
        {
            _context.LoaiLinhKiens.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(LoaiLinhKien item)
        {
            _context.LoaiLinhKiens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
