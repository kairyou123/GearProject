using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class LinhKienDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Mã sản phẩm không được phép để trống")]
        public string MaLK { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được phép để trống")]
        public string TenLK { get; set; }

        public string MoTa { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int TGBH { get; set; }
        public string Hinh { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Xin nhập số và không bỏ trống")]
        public int SLTonKho { get; set; }
        public int DaBan { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int LoaiId { get; set; }
        public LoaiLinhKienDTO Loai { get; set; }
        public int NCCId { get; set; }
        public NhaCungCapDTO NCC { get; set; }
        public ICollection<DonGiaDTO> DonGias { get; set; }
    }
}
