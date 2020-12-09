using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ILinhKienRepository : ICommonRepository<LinhKien>
    {
        public Task<IEnumerable<LinhKien>> Filter(string searchString = "", int searchCategory = 0, int searchManu = 0);
        public Task<IEnumerable<LinhKien>> getNewItems();
        public Task<IEnumerable<LinhKien>> getTopSelling();
        public Task<IEnumerable<LinhKien>> getTop10Product();

    }
}
