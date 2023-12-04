using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_WebRuou.Models
{
    public class DonHangImage
    {
        public int Id { get; set; }

        public int IdKhachHang { get; set; }

        public bool DaThanhToan { get; set; }

        public string NgayDat { get; set; }

        public string NgayGiao { get; set; }

        public int SoLuong { get; set; }

        public int TongTien { get; set; }

        public int TrangThaiGH { get; set; }
        public string Url { get; set; }
    }
}
