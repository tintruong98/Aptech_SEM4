using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_WebRuou.Models
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name id is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description id is required")]
        public string Description { get; set; }
    }
}
