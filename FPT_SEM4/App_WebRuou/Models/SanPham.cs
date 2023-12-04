using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_WebRuou.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string Name { get; set; }

        public string? Description { get; set; }

        public string UrlImage { get; set; }

        public int Price { get; set; }
        public int Promotion { get; set; }

        public int Soluong { get; set; }
    }
}
