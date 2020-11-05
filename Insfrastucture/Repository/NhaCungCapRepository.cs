using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private GearContext _context;

        public NhaCungCapRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<NhaCungCap>> getAll()
        {
            var result = await _context.NhaCungCaps.ToListAsync();
            return result;
        }
        public async Task<NhaCungCap> getById(int id)
        {
            var result = await _context.NhaCungCaps.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(NhaCungCap item)
        {
            _context.NhaCungCaps.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(NhaCungCap item)
        {
            _context.NhaCungCaps.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(NhaCungCap item)
        {
            _context.NhaCungCaps.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
