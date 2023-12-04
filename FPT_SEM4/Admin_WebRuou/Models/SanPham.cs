using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_WebRuou.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name id is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description id is required")]
        public string Description { get; set; }

        public string UrlImage { get; set; }

        [Required(ErrorMessage = "Price id is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Promotion id is required")]
        public int Promotion { get; set; }

        public int Soluong { get; set; }
    }
}
