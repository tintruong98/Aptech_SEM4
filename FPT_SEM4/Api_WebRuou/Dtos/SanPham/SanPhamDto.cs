namespace Api_WebRuou.Dtos.SanPham
{
    public class SanPhamDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string UrlImage { get; set; }

        public int Price { get; set; }
        public int Promotion { get; set; }

        public int Soluong { get; set; }
    }
}
