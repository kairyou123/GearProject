namespace Application.DTO
{
    public class CTHoaDonDTO
    {
        public int Id { get; set; }
        public LinhKienDTO LinhKien { get; set; }
        
        public decimal SoLuongBan { get; set; }
        public decimal DonGia { get; set; }
    }
}