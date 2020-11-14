using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class DonGiaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        public decimal DonGiaBan { get; set; }
        [Required(ErrorMessage = "Ngày áp dụng không được để trống")]
        public DateTime Ngay { get; set; }
        [Required(ErrorMessage = "Giảm giá không được để trống")]
        public int GiamGia { get; set; }
    }
}
