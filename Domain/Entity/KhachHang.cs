using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaKH { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Ten { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DiaChi { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SDT { get; set; }


        public ICollection<HoaDon> HoaDons{ get; set; }
}
}
