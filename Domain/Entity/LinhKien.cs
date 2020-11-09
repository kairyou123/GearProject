using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class LinhKien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaLK { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TenLK { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string HangSanXuat { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string MoTa { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public int TGBH { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgayCapNhat { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Hinh { get; set; }
        public int LoaiId{get;set;}
        public LoaiLinhKien Loai { get; set; }
        public int NCCId{get;set;}
        public NhaCungCap NCC { get; set; }

        public ICollection<ChiTietHD> ChiTietHDs  { get; set; }
        public ICollection<CTGiao> CTGiaos { get; set; }
    }
}
