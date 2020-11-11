using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ILoaiLinhKienRepository : ICommonRepository<LoaiLinhKien>
    {
        public Task<IEnumerable<LoaiLinhKien>> Filter(string searchName);
    }
}
