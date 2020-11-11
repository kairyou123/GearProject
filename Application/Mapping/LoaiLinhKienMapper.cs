using Application.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Mapping
{
    public static class LoaiLinhKienMapper
    {
        public static LoaiLinhKien LoaiLinhKienMap(this LoaiLinhKienDTO dto, LoaiLinhKien loaiLinhKien)
        {
            loaiLinhKien.MaLoai = dto.MaLoai;
            loaiLinhKien.Ten = dto.Ten;
            return loaiLinhKien;
        }
    }
}
