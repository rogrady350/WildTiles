﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WildTiles.Data;
using WildTiles.Models;

namespace WildTiles.Controllers
{
    //Attributes
    [Route("api/[controller]")] //base URL route for controller
    [ApiController] //Marks class as an API controller
    public class GameController : ControllerBase
    {
        private readonly TilesDbContext _context; //reference db context
        //constructor. TilesDbContext injected by ASP.Net dis
        public GameController(TilesDbContext context) 
        {
            _context = context; //assign context to use throughout controller
        }

        //Get method: fetch games from db
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            return Ok(await _context.Games.Include(g => g.Tiles).ToListAsyn());
        }

        //Post method: create new game in db
        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            _context.Games.Add(game);
          await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGames), new {id = game.Id}, game);
        }
    }
}
