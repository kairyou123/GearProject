using Application.DTO;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NhanVienDTO, NhanVien>()
                            .ReverseMap();
            CreateMap<LinhKienDTO, LinhKien>()
                            .ReverseMap();
        }
    }
}
