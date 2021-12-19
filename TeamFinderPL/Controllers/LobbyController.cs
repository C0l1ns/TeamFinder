using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamFinder.Models.ViewModels;
using TeamFinderDAL;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Repositories;

namespace TeamFinderPL.Controllers
{
    public class LobbyController : Controller
    {
        private readonly TeamFinderDbContext _db; // змінити всі методи де використовується котнекст
        private readonly ILobbyRepository _lobbyRepository;

        public LobbyController(TeamFinderDbContext db, ILobbyRepository lobbyRepository)
        {
            _db = db;
            _lobbyRepository = lobbyRepository;
        }

        public IActionResult Index()
        {
            // IEnumerable<Lobby> lobbyList = _db.Lobbies.ToList();
            //
            // foreach (var lobby in lobbyList)
            // {
            //     lobby.HostedGame = _db.BoardGames.FirstOrDefault(bg => bg.Id == lobby.HostedGameId);
            // }

            Task<List<Lobby>> lobbyList = _lobbyRepository.GetAll();

            return View(lobbyList.Result);
        }

        public IActionResult Create()
        {
            LobbyVM lobbyVm = new LobbyVM()
            {
                Lobby = new Lobby(),
                TypeDropDown = _db.BoardGames.Select(bg => new SelectListItem
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
            obj.Lobby.HostId = 1;

            if (ModelState.IsValid)
            {
                _db.Lobbies.Add(obj.Lobby);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}