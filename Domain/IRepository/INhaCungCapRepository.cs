using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface INhaCungCapRepository : ICommonRepository<NhaCungCap>
    {
        public Task<IEnumerable<NhaCungCap>> Filter(string searchString);
    }
}
