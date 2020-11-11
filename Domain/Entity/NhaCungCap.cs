using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MaNCC { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TenNCC { get; set; }
        public string MoTa{ get; set; }
        public int isDelete { get; set; }
    }
}
