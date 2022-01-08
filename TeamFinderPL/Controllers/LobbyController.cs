using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public LobbyController(
            ILobbyService lobbyService,
            IBoardGameRepository boardGameRepository,
            UserManager<User> userManager)
        {
            _lobbyService = lobbyService;
            _boardGameRepository = boardGameRepository;
            _userManager = userManager;
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
        [Authorize]
        public async Task< IActionResult> PostLobby(LobbyVM obj)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            obj.Lobby.Host = user;
            obj.Lobby.HostId = user.Id;
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
