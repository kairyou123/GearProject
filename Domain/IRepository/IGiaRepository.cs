using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.IRepository
{
    public interface IGiaRepository
    {

        Task<IEnumerable<DonGia>> getAll(int linhKienId);
        Task<DonGia> getById(int id);
        Task Add(DonGia entity);
        Task Update(DonGia entity);
        Task Delete(DonGia entity);
        Task<IEnumerable<DonGia>> Filter(int linhKienId, DateTime FromDate, DateTime ToDate, string ApDung = "0");
    }
}