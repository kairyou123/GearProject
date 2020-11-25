using Application.DTO;
using Application.ViewModels;
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

        /*
            Map From Model RegisterViewModel
            Return: new Application User
        */
        public static ApplicationUser MapToUser(this RegisterViewModel viewModel)
        {
            return new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                HoTen = viewModel.HoTen,
                PhoneNumber = viewModel.PhoneNumber,
                GioiTinh = viewModel.GioiTinh,
                CMND = viewModel.CMND,
                DiaChi = viewModel.DiaChi,
                isDelete = 0
            };
        }

        /*
            Map From Model EditUserViewModel
            Return: Exsited Application User
        */
        public static ApplicationUser EditMapToUser(this EditUserViewModel viewModel, ApplicationUser user)
        {
            user.UserName = viewModel.Email;
            user.HoTen = viewModel.HoTen;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.GioiTinh = viewModel.GioiTinh;
            user.CMND = viewModel.CMND;
            user.DiaChi = viewModel.DiaChi;
            return user;
        }

        public static EditUserViewModel MapToEditViewModel(this ApplicationUser user)
        {
            return new EditUserViewModel
            {
                Email = user.Email,
                HoTen = user.HoTen,
                PhoneNumber = user.PhoneNumber,
                GioiTinh = user.GioiTinh,
                CMND = user.CMND,
                DiaChi = user.DiaChi
            };
        }
    }
}
