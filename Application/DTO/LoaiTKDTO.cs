using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class LoaiTKDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Tên loại tài khoản không được phép để trống")]
        public string Name { get; set; }
    }
}
