using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        
        public int Id { get; set; }

        public int IdKhachHang { get; set; }

        public int IdSanPham { get; set; }

        public string Ten { get; set; }

        public string Url { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public int Tongtien { get; set; }

    }
}
