using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entity
{
    public class LoaiLinhKien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaLoai { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Ten { get; set; }
        public int isDelete { get; set; }
    }
}
