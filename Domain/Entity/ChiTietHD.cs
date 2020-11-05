using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entity
{
    public class ChiTietHD
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaHD { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,0)")]
        public decimal SoLuongBan { get; set; }
        [Required]
        [Column(TypeName = "decimal(12,0)")]
        public decimal DonGia { get; set; }
        public LinhKien LinhKien { get; set; }


    }
}
