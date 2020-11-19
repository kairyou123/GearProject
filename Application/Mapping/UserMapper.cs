using Application.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Mapping
{
    public static class UserMapper
    {
        public static UserDTO MapDTO(this ApplicationUser dto)
        {
            return new UserDTO
            {
                Id = dto.Id,
                HoTen = dto.HoTen,
                CMND = dto.CMND,
                DiaChi = dto.DiaChi,
                GioiTinh = dto.GioiTinh,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                ChucVu = dto.UserRoles.FirstOrDefault().Role.Name
            };
        }
    }
}
