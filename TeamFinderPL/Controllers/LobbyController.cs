using System.Collections.Generic;
using System.Linq;
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
        private readonly TeamFinderDbContext _db;
        private readonly IGenericRepository<Lobby> _lobbyRepository;

        public LobbyController(TeamFinderDbContext db, IGenericRepository<Lobby> lobbyRepository)
        {
            _db = db;
            _lobbyRepository = lobbyRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Lobby> lobbyList = _db.Lobbies.ToList();

            foreach (var lobby in lobbyList)
            {
                lobby.HostedGame = _db.BoardGames.FirstOrDefault(bg => bg.BGameId == lobby.HostedGameId);
            }

            return View(lobbyList);
        }

        public IActionResult Create()
        {
            LobbyVM lobbyVm = new LobbyVM()
            {
                Lobby = new Lobby(),
                TypeDropDown = _db.BoardGames.Select(bg => new SelectListItem
                {
                    Text = bg.BGameName,
                    Value = bg.BGameId.ToString(),
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