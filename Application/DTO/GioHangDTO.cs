using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class GioHangDTO
    {
        public string UserId { get; set; }
        public UserDTO User { get; set; }
        public int LinhKienId { get; set; }
        public LinhKienDTO LinhKien { get; set; }
        public int SoLuong { get; set; }
    }
}
