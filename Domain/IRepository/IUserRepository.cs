using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        public Task Add(ApplicationUser entity, string password, string role);
        public Task Update(ApplicationUser entity, string role, string password = "");
        public Task Delete(ApplicationUser entity);
        public Task<IEnumerable<ApplicationUser>> getAll();
        public Task<IEnumerable<ApplicationUser>> Filter(string searchString = "", string role = "");
        public Task<ApplicationUser> getByName(string Name);
        public Task<ApplicationUser> getById(string Id);
        public Task<ApplicationUser> getByEmail(string Email);
        public Task<IEnumerable<ApplicationUser>> getAllKhachHang();
    }
}
