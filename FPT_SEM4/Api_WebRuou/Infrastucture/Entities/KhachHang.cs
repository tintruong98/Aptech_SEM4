using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Api_WebRuou.Core.Enums.Enums;

namespace Api_WebRuou.Infrastucture.Entities
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        
        public string Phone { get; set; }

        public Status Status { get; set; }
    }
}
