using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class HoaDonNhapHang
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaHD { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgayLapHD { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgayGiao { get; set; }

        public int NCCId{get;set;}
        public NhaCungCap NCC { get; set; }

        public ICollection<CTGiao> CTGiaos { get; set; }
        public int isDelete { get; set; }
    }
}
