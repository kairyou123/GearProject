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
                            .ForMember(x => x.Loai, y => y.MapFrom(z => z.Loai))
                            .ForMember(x => x.NCC, y => y.MapFrom(z => z.NCC))
                            .ForMember(x => x.DonGias, y => y.MapFrom(z => z.DonGias))
                            .ReverseMap();
            CreateMap<LoaiLinhKienDTO, LoaiLinhKien>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id !=null ))
                            .ReverseMap();
            CreateMap<NhaCungCapDTO, NhaCungCap>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id != null))
                            .ReverseMap();

        }
    }
}
