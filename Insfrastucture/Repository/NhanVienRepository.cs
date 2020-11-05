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
    public class NhanVienRepository : INhanVienRepository
    {
        private GearContext _context;

        public NhanVienRepository(GearContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<NhanVien>> getAll()
        {
            var result = await _context.NhanViens.ToListAsync();
            return result;
        }
        public async Task<NhanVien> getById(int id)
        {
            var result = await _context.NhanViens.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(NhanVien item)
        {
            _context.NhanViens.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Update(NhanVien item)
        {
             _context.NhanViens.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(NhanVien item)
        {
            _context.NhanViens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
