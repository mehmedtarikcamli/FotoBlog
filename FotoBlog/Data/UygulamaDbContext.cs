using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FotoBlog.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        }

        public DbSet<Gonderi> Gonderiler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gonderi>().HasData(
                    new Gonderi { Id = 1, Baslik = "Batarken güneş ardında tepelerin, veda vakti geldi teletabilerin..", ResimYolu = "01.jpg" },
                    new Gonderi { Id = 2, Baslik = "Mutlu gamsız yaşar kuşlar. Yuvaları ağaçlar taşlar.", ResimYolu = "02.jpg" }
                );
        }
    }
}
