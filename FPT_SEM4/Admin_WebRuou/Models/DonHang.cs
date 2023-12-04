using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_WebRuou.Models
{
    [Table("DonHangs")]
    public class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;set; }

        public int IdKhachHang { get;set; }

        public bool DaThanhToan { get; set; }

        public string NgayDat { get; set; }

        public string NgayGiao { get; set; }

        public int SoLuong { get; set; }

        public int TongTien { get; set; }
        
        [Range(0, 3, ErrorMessage = "TrangThaiGH from 0 to 3")]
        public int TrangThaiGH { get; set; }
    }
}
