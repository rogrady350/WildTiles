using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WildTiles.Data;
using WildTiles.Models;

namespace WildTiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly TilesDbContext _context;
        //constructor
        public GameController(TilesDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            return Ok(await _context.Games.Include(g => g.Tiles).ToListAsyn());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            _context.Games.Add(game);
          await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGames), new {id = game.Id}, game);
        }
    }
}
