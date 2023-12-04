using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_WebRuou.Models
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
