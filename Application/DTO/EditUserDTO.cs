using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class EditUserDTO
    {
           
            public string Email { get; set; }

           
            public string CurrentPassword { get; set; }

            
            public string NewPassword { get; set; }
            public string NewPasswordConfirm { get; set; }
            
            public string PhoneNumber { get; set; }

            public string HoTen { get; set; }
           
            public string DiaChi { get; set; }
            public string GioiTinh { get; set; }
            public string CMND { get; set; }
    }
}
