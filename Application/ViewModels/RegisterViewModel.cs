using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email không được phép để trống")]
        [RegularExpression(@"[a-zA-Z0-9\-_]+@+[a-zA-Z]+\.+[a-z]+$", ErrorMessage = "Email sai định dạng")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Mật khẩu ít nhất 5 ký tự")]
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được phép để trống")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chỉ được nhập số")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Họ tên không được phép để trống")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được phép để trống")]
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
    }
}
