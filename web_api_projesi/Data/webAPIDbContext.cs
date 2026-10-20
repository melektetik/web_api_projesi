using Microsoft.EntityFrameworkCore;

namespace web_api_projesi.Data
{
    public class webAPIDbContext : DbContext
    {
        public webAPIDbContext(
            DbContextOptions<webAPIDbContext> options) : base(options)
        {
        }

        public DbSet<web_api_projesi.Models.Kullanıcılar> Kullanıcılar { get; set; }

        public DbSet<web_api_projesi.Models.Kategori> Kategoriler { get; set; }
    }
}