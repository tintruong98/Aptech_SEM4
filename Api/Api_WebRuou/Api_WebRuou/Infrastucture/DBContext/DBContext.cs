using Api_WebRuou.Infrastucture.Entities;
using Microsoft.EntityFrameworkCore;


namespace Api_WebRuou.Infrastucture.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<KhuyenMai> SKhuyenMais { get; set; }

        public DbSet<LienHe> LienHes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<TheLoai> TheLoais { get; set; }

        public DbSet<ThuongHieu> ThuongHieus { get; set; }

        public DbSet<TintucBlog> TintucBlogs { get; set; }

    }
}
