using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class TonKhoRepository : ITonKhoRepository
    {
        private GearContext _context;

        public TonKhoRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TonKho>> getAll()
        {
            var result = await _context.TonKhos.ToListAsync();
            return result;
        }
        public async Task<TonKho> getById(int id)
        {
            var result = await _context.TonKhos.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(TonKho item)
        {
            _context.TonKhos.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TonKho item)
        {
            _context.TonKhos.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TonKho item)
        {
            _context.TonKhos.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
