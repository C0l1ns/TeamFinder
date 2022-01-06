using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamFinder.Models.ViewModels;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderPL.Controllers
{
    public class LobbyController : Controller
    {
        private readonly ILobbyService _lobbyService;
        private readonly IBoardGameRepository _boardGameRepository;

        public LobbyController(
            ILobbyService lobbyService,
            IBoardGameRepository boardGameRepository)
        {
            _lobbyService = lobbyService;
            _boardGameRepository = boardGameRepository;
        }

        public async Task<IActionResult> Index()
        {
            var lobbies = await _lobbyService.GetAll();

            foreach (var lobby in lobbies)
            {
                lobby.HostedGame = await _boardGameRepository.GetById(lobby.HostedGameId);
            }

            return View(lobbies);
        }

        public IActionResult Create()
        {
            LobbyVM lobbyVm = new LobbyVM()
            {
                Lobby = new Lobby(),
                TypeDropDown = _boardGameRepository
                    .GetAll()
                    .Result
                    .Select(bg => new SelectListItem
                    {
                        Text = bg.Name,
                        Value = bg.Id.ToString(),
                    })
            };

            return View(lobbyVm);
        }

        [HttpPost]
        public IActionResult PostLobby(LobbyVM obj)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");
            
            _lobbyService.Create(obj.Lobby);
            return RedirectToAction("Index");
        }


        // [HttpDelete]
        public async Task<IActionResult> DeleteLobby(int id)
        {
            if (ModelState.IsValid)
            {
                await _lobbyService.Delete(id);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var obj = await _lobbyService.GetById(id);

            if (obj == null) return RedirectToAction("Index");

            LobbyVM lobbyVm = new LobbyVM()
            {
                Lobby = obj,
                TypeDropDown = _boardGameRepository
                    .GetAll()
                    .Result
                    .Select(bg => new SelectListItem
                    {
                        Text = bg.Name,
                        Value = bg.Id.ToString(),
                    })
            };

            return View(lobbyVm);
        }

        public IActionResult UpdateLobby(LobbyVM obj)
        {
            if (ModelState.IsValid)
            {
                _lobbyService.Update(obj.Lobby);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }
    }
}
