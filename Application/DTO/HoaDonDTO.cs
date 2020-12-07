using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class HoaDonDTO
    {

        public int Id { get; set; }

        public string MaHD { get; set; }

        public DateTime NgayLapHD { get; set; }
        public DateTime NgayGiao { get; set; }

        public decimal TiGia { get; set; }

        public string UserId { get; set; }
        public string TinhTrang { get; set; }
        public UserDTO User { get; set; }
        public ICollection<CTHoaDonDTO> ChiTietHDs { get; set; }
    }
}
