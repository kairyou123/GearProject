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
        [Column(TypeName = "ntext")]
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
        public ICollection<DonGia> DonGias{ get; set; }

        public ICollection<ChiTietHD> ChiTietHDs  { get; set; }
        public ICollection<CTGiao> CTGiaos { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
        public int SLTonKho { get; set; }
        public int DaBan { get; set; }
        public int isDelete { get; set; }
    }
}
