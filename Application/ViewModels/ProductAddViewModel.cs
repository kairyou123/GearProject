using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Ít nhất phải có 1 hình")]
        public ICollection<IFormFile>  files { get; set; }
        [Required(ErrorMessage = "Mã sản phẩm không được phép để trống")]
        public string MaLK { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được phép để trống")]
        public string TenLK { get; set; }

        public string MoTa { get; set; }
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int TGBH { get; set; }
        public string Hinh { get; set; }
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int SLTonKho { get; set; }

        public int Loai { get; set; }
        public int NCC { get; set; }
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int Gia{ get; set; }
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int GiamGia{ get; set; }
    }
}
