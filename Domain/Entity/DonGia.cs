using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class DonGia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime Ngay { get; set; }
        [Required]
        [Column(TypeName = "decimal(12,0)")]
        public decimal DonGiaBan { get; set; }
        [Required]
        public int GiamGia { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool ApDung { get; set; }
        public int LinhKienId { get; set; }
        public LinhKien LinhKien { get; set; }
    }
}
