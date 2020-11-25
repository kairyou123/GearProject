using System;
using System.ComponentModel.DataAnnotations;
using Application.DTO;

namespace Application.ViewModels
{
    public class GiaEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal DonGiaBan { get; set; }
        [Required(ErrorMessage = "Ngày áp dụng không được để trống")]
        public DateTime Ngay { get; set; }
        [Required(ErrorMessage = "Giảm giá không được để trống")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int GiamGia { get; set; }
        public string ApDung { get; set; }
        public int LinhKienId { get; set; }
    }
}