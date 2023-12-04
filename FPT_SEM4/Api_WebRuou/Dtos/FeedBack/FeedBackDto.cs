namespace Api_WebRuou.Dtos.FeedBack
{
    public class FeedBackDto
    {
        public int IdKhachHang { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public string Contents { get; set; }
        public string ThoiGianFeed { get; set; }
        public int Evaluate { get; set; }
    }
}
