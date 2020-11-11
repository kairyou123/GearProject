using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class NhaCungCapDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã nhà cung cấp không được phép để trống")]
        public string MaNCC { get; set; }
        [Required(ErrorMessage = "Tên loại không được phép để trống")]
        public string TenNCC { get; set; }
        public string MoTa { get; set; }
    }
}
