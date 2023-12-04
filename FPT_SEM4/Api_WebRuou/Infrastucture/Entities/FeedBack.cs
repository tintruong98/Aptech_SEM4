using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("FeedBacks")]

    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        public int IdKhachHang { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public string Contents { get; set; }
        public string ThoiGianFeed { get; set; }
        public int Evaluate { get; set; }

    }
}
