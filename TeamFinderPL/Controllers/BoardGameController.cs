using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderPL.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        
        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }
        
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
           var boardGames = await _boardGameService.GetAll();

            return View(boardGames);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            BoardGame boardGame = new BoardGame();

            return View(boardGame);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult PostBoardGame(BoardGame boardGame)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");
            
            _boardGameService.Create(boardGame);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBoardGame(int id)
        {
            if (ModelState.IsValid)
            {
                await _boardGameService.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var boardGame = await _boardGameService.GetById(id);

            if (boardGame == null) return RedirectToAction("Index");

            return View(boardGame);
        }

        [Authorize(Roles = "admin")]
        public IActionResult UpdateBoardGame(BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                _boardGameService.Update(boardGame);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }
    }
}
