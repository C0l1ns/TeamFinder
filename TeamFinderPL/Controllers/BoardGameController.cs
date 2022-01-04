using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderPL.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameRepository _boardGameRepository;
        
        public BoardGameController(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }
        
        public async Task<IActionResult> Index()
        {
           var bGameList = await _boardGameRepository.GetAll();

            return View(bGameList);
        }

        public IActionResult Create()
        {
            BoardGame boardGame = new BoardGame();

            return View(boardGame);
        }

        [HttpPost]
        public IActionResult PostBoardGame(BoardGame entity)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");
            _boardGameRepository.Create(entity);
            _boardGameRepository.Save();
            return RedirectToAction("Index");

        }
    }
}