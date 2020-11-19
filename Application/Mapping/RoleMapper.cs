using Application.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Mapping
{
    public static class RoleMapper
    {
        public static ApplicationRole AddMap(this LoaiTKDTO dto)
        {
            return new ApplicationRole
            {
                Name = dto.Name,
                NormalizedName = dto.Name.ToUpper(),
        };
        }

        public static ApplicationRole EditMap(this LoaiTKDTO dto, ApplicationRole loaiTK)
        {
            loaiTK.Name = dto.Name;
            loaiTK.NormalizedName = dto.Name.ToUpper();
            return loaiTK;
        }
    }
}
