using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamFinder.Data;
using TeamFinder.Models;
using TeamFinderDAL.Models.Entities;

namespace TeamFinder.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly TeamFinderDbContext _db;
        
        public BoardGameController(TeamFinderDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
           var bGameList = _db.BoardGames.ToList();

            return View(bGameList);
        }

        public IActionResult Create()
        {
            BoardGame boardGame = new BoardGame();

            return View(boardGame);
        }

        [HttpPost]
        public IActionResult PostBoardGame(BoardGame obj)
        {
            if (ModelState.IsValid)
            {
                _db.BoardGames.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}