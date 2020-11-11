using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class LoaiLinhKienDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã loại không được phép để trống")]
        public string MaLoai { get; set; }
        [Required(ErrorMessage = "Tên loại không được phép để trống")]
        public string Ten { get; set; }
    }
}
