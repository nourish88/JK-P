using DataAccess.Configs;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Contexts
{
    public class JkiContext : DbContext
    {
        public DbSet<Faaliyet> Faaliyet { get; set; }
        public DbSet<Ihbar> Ihbar { get; set; }
        public DbSet<IhbarDurumu> IhbarDurumu { get; set; }
        public DbSet<IslemDurumu> IslemDurumu { get; set; }
        public DbSet<Olay> Olay { get; set; }
        public DbSet<OlayIhbar> OlayIhbar { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
