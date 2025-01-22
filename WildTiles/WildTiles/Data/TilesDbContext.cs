using Microsoft.EntityFrameworkCore;
using WildTiles.Models;

namespace WildTiles.Data
{
    public class TilesDbContext : DbContext
    {
        //constructor, creates connection to db, use dependency injection. connection set in appsettings.json
        public TilesDbContext(DbContextOptions<TilesDbContext> options) : base(options) { }
    
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tile> Tiles { get; set; }
    }
}
