namespace SmartRecruit.Application.DTO.Wallet
{
    public class TransactionExportDto
    {
        public long MaGD { get; set; }
        public string NguoiDung { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
        public string LoaiGiaoDich { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public string MaDonHang { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string ThoiGian { get; set; } = string.Empty;
    }
}
