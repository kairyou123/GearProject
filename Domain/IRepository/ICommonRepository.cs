using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICommonRepository<T> where T : class
    {
        Task<IEnumerable<T>> getAll();
        Task<T> getById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
