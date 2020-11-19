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
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Add(ApplicationUser entity, string password, string role)
        {
             await _userManager.CreateAsync(entity, password);
             await _userManager.AddToRoleAsync(entity, role);
        }

        public async Task Delete(ApplicationUser entity)
        {
            entity.isDelete = 1;
           await _userManager.UpdateAsync(entity);
        }

        public async Task<IEnumerable<ApplicationUser>> getAll()
        {
            return await _userManager.Users.Where(x => x.isDelete == 0).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }

        public async Task<ApplicationUser> getByName(string Name)
        {
            var user =  await _userManager.Users.Where(x => x.HoTen == Name && x.isDelete == 0).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync();
            return user;
        }

        public async Task<ApplicationUser> getById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<ApplicationUser>> Filter(string searchString, string role)
        {
            var query = _userManager.Users.AsQueryable();

            if(searchString != null && searchString != "")
            {
                query = query.Where(x => x.HoTen.Contains(searchString));
            }
            if(role != null && role != "")
            {
                query = query.Where(u => u.UserRoles.FirstOrDefault().Role.Name == role);
            }

            query = query.Where(x => x.isDelete == 0).Include(u => u.UserRoles).ThenInclude(ur => ur.Role);

            return  await query.ToListAsync();
        }

        public async Task Update(ApplicationUser entity, string role)
        {

            if (role != null && role != "")
            {
                var currentRoles = await _userManager.GetRolesAsync(entity);

                var currentRole = currentRoles.FirstOrDefault();
                if(currentRole != role )
                {
                    Task A = _userManager.RemoveFromRoleAsync(entity, currentRole);
                    Task B = _userManager.AddToRoleAsync(entity, role);
                    await Task.WhenAll(A, B);

                }
            }

            await _userManager.UpdateAsync(entity);
            
        }
    }
}
