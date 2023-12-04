using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_WebRuou.Models
{
    [Table("ChiTietDonHangs")]
    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong{ get; set; }
        public int GiaTien { get; set; }
      
    }
}
