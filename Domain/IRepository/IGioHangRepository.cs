using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IGioHangRepository 
    {
        public Task<IEnumerable<GioHang>> getAll();
        public Task<IEnumerable<GioHang>> getByUser(string id);
        public Task<GioHang> getById(string userid, int linhkienid);
        public Task<int> getCartsNum(string id);
        public Task Add(GioHang item);
        public Task Update(GioHang item);
        public Task Delete(GioHang item);
        public Task DeleteRange(IEnumerable<GioHang> items);
    }
}
