using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TeamFinder.Data;
using TeamFinder.Models;
using TeamFinder.Models.ViewModels;
using TeamFinderDAL.Models.Entities;

namespace TeamFinder.Controllers
{
    public class LobbyController : Controller
    {
        private readonly TeamFinderDbContext _db;

        public LobbyController(TeamFinderDbContext db)
        {
            _db = db;
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