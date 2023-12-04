using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_WebRuou.Models
{
    public class FeedBackDetails
    {
        public int Id { get; set; }
        public int IdKhachHang { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public string Contents { get; set; }
        public string  ThoiGianFeed { get; set; }
        public int Evaluate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }

    }
}
