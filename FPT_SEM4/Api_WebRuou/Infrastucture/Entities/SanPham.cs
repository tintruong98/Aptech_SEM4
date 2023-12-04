using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }

        public string? Description { get; set; }

        public string UrlImage { get; set; }

        public int Price { get; set; }
        public int Promotion { get; set; }

        public int Soluong { get; set; }
    }
}
