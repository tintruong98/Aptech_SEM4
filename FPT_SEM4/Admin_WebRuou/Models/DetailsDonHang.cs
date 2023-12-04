using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_WebRuou.Models
{
    public class DetailsDonHang
    {
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaTien { get; set; }
        public int ThanhTien { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public int Promotion { get; set; }
    }
}
