using Api_WebRuou.Infrastucture.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Infrastucture.DataBaseContext
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<KhuyenMai> KhuyenMais { get; set; }

        public DbSet<LienHe> LienHes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<TheLoai> TheLoais { get; set; }

        public DbSet<ThuongHieu> ThuongHieus { get; set; }

        public DbSet<TintucBlog> TintucBlogs { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<DonHang> DonHangs { get; set; }

        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<Cart> Carts { get; set; }

        internal void UpdateAsync(DonHang donhang)
        {
            throw new NotImplementedException();
        }
    }
}
