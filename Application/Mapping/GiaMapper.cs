using Application.DTO;
using Application.ViewModels;
using AutoMapper;
using Domain.Entity;

namespace Application.Mapping
{
    public static class GiaMapper
    {

        public static GiaEditViewModel editMap(this DonGia dongia)
        {
            var ApDung = "1";
            if (dongia.ApDung == true)
            {
                ApDung = "0";
            }

            return new GiaEditViewModel
            {
                Id = dongia.Id,
                DonGiaBan = dongia.DonGiaBan,
                Ngay = dongia.Ngay,
                ApDung = ApDung,
                LinhKienId = dongia.LinhKienId,
                GiamGia = dongia.GiamGia
            };
        }
    }
}