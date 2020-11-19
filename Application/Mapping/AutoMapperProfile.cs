﻿using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LinhKien, LinhKienDTO>()
                            .ForMember(x => x.Loai, y => y.MapFrom(z => z.Loai))
                            .ForMember(x => x.NCC, y => y.MapFrom(z => z.NCC))
                            .ForMember(x => x.DonGias, y => y.MapFrom(z => z.DonGias))
                            .ReverseMap(); 
            CreateMap<LinhKien, DonGiaDTO>() 
                            .ReverseMap(); 
            CreateMap<DonGia, DonGiaDTO>()
                             .ReverseMap();
            CreateMap<ApplicationRole, LoaiTKDTO>()
                             .ReverseMap();
            CreateMap<LoaiLinhKienDTO, LoaiLinhKien>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id !=null ))
                            .ReverseMap();
            CreateMap<NhaCungCapDTO, NhaCungCap>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id != null))
                            .ReverseMap();
            CreateMap<UserDTO, ApplicationUser>()
                            .ForMember(x => x.Id, opt => opt.Condition(id => id != null))
                            .ForMember(x => x.PasswordHash, opt => opt.Ignore())
                            .ReverseMap();

        }
    }
}
