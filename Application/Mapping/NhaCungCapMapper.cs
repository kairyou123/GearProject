using Application.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Mapping
{
    public static class NhaCungCapMapper
    {
        public static NhaCungCap NhaCungCapEditMap(this NhaCungCapDTO dto, NhaCungCap ncc)
        {
            ncc.MaNCC = dto.MaNCC;
            ncc.TenNCC = dto.TenNCC;
            ncc.MoTa = dto.MoTa;
            return ncc;
        }
    }
}
