using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App_WebRuou.Models
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
