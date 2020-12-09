using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class GioHang
    {
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        public ApplicationUser User{ get; set; }
        public int LinhKienId { get; set; }
        public LinhKien LinhKien { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int  SoLuong { get; set; }
    }
}
