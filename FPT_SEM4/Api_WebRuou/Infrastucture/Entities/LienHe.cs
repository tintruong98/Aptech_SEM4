using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("LienHe")]
    public class LienHe
    {
        [Key]
        public int Id { get; set; }
        public string KhachHangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Phone { get; set; }
    }
}
