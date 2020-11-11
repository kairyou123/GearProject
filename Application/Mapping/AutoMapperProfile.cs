using Application.DTO;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LinhKienDTO, LinhKien>()
                            .ReverseMap();
            CreateMap<LoaiLinhKienDTO, LoaiLinhKien>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id !=null ))
                            .ReverseMap();
        }
    }
}
