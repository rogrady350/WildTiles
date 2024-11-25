using Microsoft.EntityFrameworkCore;
using WildTiles.Models;

namespace WildTiles.Data
{
    public class TilesDbContext : DbContext
    {
        public string DbPath { get; }

        //constructor, creates connection to db
        public TilesDbContext()
        {
            DbPath = "TilesDbContext.db";
        }

        //tells ef how connection works
        //change UseSqlite to UseMySql when migrating
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tile> Tiles { get; set; }
    }
}
