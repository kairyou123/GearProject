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
            var result = await _context.LinhKiens.Where(i => i.isDelete == 0).Include(i => i.Loai).Include(i => i.NCC).Include(i => i.DonGias).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<LinhKien>> getTopSelling()
        {
            var result = await _context.LinhKiens.Where(i => i.isDelete == 0 && i.SLTonKho > 0)
                                                .Include(i => i.Loai)
                                                .Include(i => i.NCC)
                                                .Include(i => i.DonGias)
                                                .OrderByDescending(i => i.DaBan)
                                                .Take(12)
                                                .ToListAsync();
            result.ForEach(i => i.DonGias = i.DonGias.Where(dongia => dongia.ApDung).ToList());
            return result;
        }
        public async Task<IEnumerable<LinhKien>> getNewItems()
        {
            var result = await _context.LinhKiens.Where(i => i.isDelete == 0 && i.SLTonKho > 0)
                                                .Include(i => i.Loai)
                                                .Include(i => i.NCC)
                                                .Include(i => i.DonGias)
                                                .OrderByDescending(i => i.NgayCapNhat)
                                                .Take(12)
                                                .ToListAsync();
            result.ForEach(i => i.DonGias = i.DonGias.Where(dongia => dongia.ApDung).ToList());
            return result;
        }
        public async Task<LinhKien> getById(int id)
        {
            var result = await _context.LinhKiens.Where(i => i.Id == id && i.isDelete == 0).Include(i => i.Loai).Include(i => i.NCC).Include(i => i.DonGias).FirstOrDefaultAsync();
            return result;
        }
        public async Task Add(LinhKien item)
        {
            item.isDelete = 0;
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
            item.isDelete = 1;
            _context.LinhKiens.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LinhKien>> Filter(string searchString, int searchCategory, int searchManu)
        {
            var query = _context.LinhKiens.AsQueryable();
            if (searchString != "")
            {
                query = query.Where(i => i.TenLK.Contains(searchString));
            }
            if (searchCategory != 0)
            {
                query = query.Where(i => i.Loai.Id == searchCategory);
            }
            if (searchManu != 0)
            {
                query = query.Where(i => i.NCC.Id == searchManu);
            }
            query = query.Where(i => i.isDelete == 0).Include(i => i.Loai).Include(i => i.NCC).Include(i => i.DonGias);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<LinhKien>> getTop10Product()
        {
            var result = await _context.LinhKiens.Where(i => i.isDelete == 0).OrderByDescending(i => i.DaBan).Take(10).ToListAsync();

            return result;
        }
    }
}
