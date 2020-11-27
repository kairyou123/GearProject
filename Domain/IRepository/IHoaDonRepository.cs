using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IHoaDonRepository : ICommonRepository<HoaDon>
    {
        public Task<IEnumerable<HoaDon>> getByUser(string id);
    }
}
