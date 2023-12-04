using Api_WebRuou.Infrastucture.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Infrastucture
{
    public class GioHang
    {    
        public int IdSanPham { get; set; }

        public string Ten { get; set; }

        public string Url { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public int Tongtien { get { return SoLuong * DonGia; } }
    }
}
