using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_WebRuou.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName id is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password id is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address id is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone id is required")]
        public string Phone { get; set; }

        public int Status { get; set; }
    }
}
