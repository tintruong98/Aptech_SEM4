using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("NhapHang")]
    public class NhapHang
    {
        [Key]
        public int Id { get; set; }

        public int Name { get;set; }

        public int SoLuong { get; set; }

        public string? Decription { get; set; }

    }
}
