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
        public Task<IEnumerable<HoaDon>> Filter(string searchString = "", string orderBy = "", string tinhTrang = "", DateTime fromDate = default, DateTime toDate = default);
        public Task<IEnumerable<HoaDon>> getOrderThreeMonthAgoAndNow();
    }
}
