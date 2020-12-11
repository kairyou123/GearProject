
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaHD { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgayLapHD { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? NgayGiao { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TiGia { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TinhTrang { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<ChiTietHD> ChiTietHDs { get; set; }
    }
}
