using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IRoleRepository
    {
        public Task Add(ApplicationRole entity);
        public Task Update(ApplicationRole entity);
        public Task Delete(ApplicationRole entity);
        public Task<IEnumerable<ApplicationRole>> getAll();
        public Task<IEnumerable<ApplicationRole>> Filter(string searchString="");
        public Task<ApplicationRole> getByName(string Name);
        public Task<ApplicationRole> getById(string Id);
    }
}
