using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Insfrastucture.Repository
{
    public class GiaRepository : IGiaRepository
    {
        public readonly GearContext _context;

        public GiaRepository(GearContext context)
        {
            _context = context;
        }

        public async Task Add(DonGia entity)
        {
            _context.DonGias.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DonGia entity)
        {
            _context.DonGias.Remove(entity);
            await _context.SaveChangesAsync();

            var gias = await getAll(entity.LinhKienId);

            if (!checkApDung(gias))
            {
                var gia = gias.FirstOrDefault();
                gia.ApDung = true;
                _context.DonGias.Update(gia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DonGia>> Filter(int linhKienId, DateTime FromDate, DateTime ToDate, string ApDung = "")
        {
            var query = _context.DonGias.AsQueryable();

            query = query.Where(u => u.Ngay >= FromDate && u.Ngay <= ToDate && u.LinhKienId == linhKienId);

            if (ApDung == "0")
            {
                query = query.Where(u => u.ApDung == true);
            }
            else if (ApDung == "1")
            {
                query = query.Where(u => u.ApDung == false);
            }

            query = query.Include(u => u.LinhKien).OrderBy(u => u.Ngay);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<DonGia>> getAll(int linhKienId)
        {
            return await _context.DonGias.Where(dg => dg.LinhKienId == linhKienId).Include(u => u.LinhKien).OrderBy(u => u.Ngay).ToListAsync();
        }

        public async Task<DonGia> getById(int id)
        {
            return await _context.DonGias.Where(u => u.Id == id).Include(u => u.LinhKien).OrderBy(u => u.Ngay).FirstOrDefaultAsync();
        }

        public async Task Update(DonGia entity)
        {
            var gias = await getAll(entity.LinhKienId);
            if (entity.ApDung == true)
            {
                foreach (var gia in gias)
                {
                    if (gia.Id != entity.Id && gia.ApDung == true)
                    {
                        gia.ApDung = false;
                        _context.DonGias.Update(gia);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else
            {

                if (!checkApDung(gias))
                {
                    var gia = gias.FirstOrDefault();
                    gia.ApDung = true;
                    _context.DonGias.Update(gia);
                    await _context.SaveChangesAsync();
                }
            }


            _context.DonGias.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool checkApDung(IEnumerable<DonGia> gias)
        {
            var flg = false;

            foreach (var gia in gias)
            {
                if (gia.ApDung == true)
                {
                    flg = true;
                    break;
                }
            }

            return flg;
        }
    }
}