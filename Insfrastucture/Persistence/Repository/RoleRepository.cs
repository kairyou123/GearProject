using Domain.Entity;
using Domain.IRepository;
using Insfrastucture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastucture.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleRepository(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Add(ApplicationRole entity)
        {
            await _roleManager.CreateAsync(entity);
        }

        public async Task Delete(ApplicationRole entity)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(entity.Name);
            foreach (var user in usersInRole)
            {
                Task A = _userManager.RemoveFromRoleAsync(user, entity.Name);
                Task B = _userManager.AddToRoleAsync(user, "Khách hàng");
                await Task.WhenAll(A, B);
            }

            await _roleManager.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ApplicationRole>> getAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<ApplicationRole> getByName(string Name)
        {
            return await _roleManager.FindByNameAsync(Name);
        }

        public async Task<ApplicationRole> getById(string Id)
        {
            return await _roleManager.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<ApplicationRole>> Filter(string searchString = "")
        {
            var query = _roleManager.Roles.AsQueryable();

            if (searchString != null && searchString != "")
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }

            return await query.ToListAsync();
        }

        public async Task Update(ApplicationRole entity)
        {
            await _roleManager.UpdateAsync(entity);
        }
    }
}
