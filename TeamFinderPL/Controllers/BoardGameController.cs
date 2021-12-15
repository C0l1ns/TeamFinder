using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamFinderDAL;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Repositories;

namespace TeamFinderPL.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly TeamFinderDbContext _db;
        private readonly IGenericRepository<BoardGame> _boardGameRepository;
        
        public BoardGameController(TeamFinderDbContext db, IGenericRepository<BoardGame> boardGameRepository)
        {
            _db = db;
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