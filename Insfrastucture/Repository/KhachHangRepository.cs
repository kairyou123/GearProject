using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private GearContext _context;

        public KhachHangRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<KhachHang>> getAll()
        {
            var result = await _context.KhachHangs.ToListAsync();
            return result;
        }
        public async Task<KhachHang> getById(int id)
        {
            var result = await _context.KhachHangs.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(KhachHang item)
        {
            _context.KhachHangs.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(KhachHang item)
        {
            _context.KhachHangs.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(KhachHang item)
        {
            _context.KhachHangs.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
