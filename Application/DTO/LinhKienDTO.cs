using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class LinhKienDTO
    {

        public int Id { get; set; }

        public string MaLK { get; set; }

  
        public string TenLK { get; set; }

    
        public string HangSanXuat { get; set; }

      
        public string MoTa { get; set; }

      
        public int TGBH { get; set; }

        public DateTime NgayCapNhat { get; set; }

       
        public string Hinh { get; set; }

        public LoaiLinhKien Loai { get; set; }
        public NhaCungCap NCC { get; set; }
    }
}
