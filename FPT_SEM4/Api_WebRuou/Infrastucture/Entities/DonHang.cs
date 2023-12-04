using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Api_WebRuou.Core.Enums.Enums;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("DonHangs")]
    public class DonHang
    {
        [Key]
        public int Id { get;set; }

        public int IdKhachHang { get;set; }

        public bool DaThanhToan { get; set; }

        public string NgayDat { get; set; }

        public string NgayGiao { get; set; }

        public int SoLuong { get; set; }

        public int TongTien { get; set; }

        public int TrangThaiGH { get; set; }
    }
}
