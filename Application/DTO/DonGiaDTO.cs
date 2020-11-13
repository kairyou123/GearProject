using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class DonGiaDTO
    {
        public int Id { get; set; }
        public decimal DonGia { get; set; }
        public DateTime Ngay { get; set; }
        public int GiamGia { get; set; }
    }
}
