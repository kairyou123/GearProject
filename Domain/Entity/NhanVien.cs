using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaNV { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Ten { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string GioiTinh { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DiaChi { get; set; }
    }
}
