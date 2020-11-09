using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int  SoLuong { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime NgayMua { get; set; }
        public int LinhKienId {get;set;}
        public LinhKien LinhKien { get; set; }
    }
}
