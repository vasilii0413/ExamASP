using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lab2.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }
    }
}
