using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class NhanVienDTO
    {
        public int Id { get; set; }

        public string MaNV { get; set; }
        
        public string Ten { get; set; }
        
        public string GioiTinh { get; set; }
        
        public DateTime NgaySinh { get; set; }
        
        public string DiaChi { get; set; }
    }
}
