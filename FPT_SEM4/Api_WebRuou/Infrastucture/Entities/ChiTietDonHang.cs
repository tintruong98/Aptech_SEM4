using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("ChiTietDonHangs")]
    public class ChiTietDonHang
    {
        [Key]
        public int Id { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong{ get; set; }
        public int GiaTien { get; set; }
      
    }
}
