using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class CTGiao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int SoLuong { get; set; }
        [Required]
        [Column(TypeName = "decimal(12,0)")]
        public decimal DonGia { get; set; }
        public LinhKien LinhKien { get; set; }
        public HoaDonNhapHang HDNhapHang { get; set; }
    }
}
