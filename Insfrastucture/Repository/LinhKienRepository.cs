using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class LinhKienRepository : ILinhKienRepository
    {
        private GearContext _context;

        public LinhKienRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LinhKien>> getAll()
        {
            var result = await _context.LinhKiens.Include(i => i.Loai).Include(i => i.NCC).ToListAsync();
            return result;
        }
        public async Task<LinhKien> getById(int id)
        {
            var result = await _context.LinhKiens.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(LinhKien item)
        {
            _context.LinhKiens.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(LinhKien item)
        {
            _context.LinhKiens.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(LinhKien item)
        {
            _context.LinhKiens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
