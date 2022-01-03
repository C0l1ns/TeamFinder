using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamFinder.Models.ViewModels;
using TeamFinderBL.Interfaces;
using TeamFinderDAL;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Repositories;

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
            var lobbyList = (await _lobbyService.GetAllLobbies());

            foreach (var lobby in lobbyList)
            {
                lobby.HostedGame = await _boardGameRepository.GetById(lobby.HostedGameId);
            }

            return View(lobbyList);
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
            if (ModelState.IsValid)
            {
                _lobbyService.CreateLobby(obj.Lobby);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }


        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _lobbyService.DeleteLobby(id);
            }

            return RedirectToAction("Index");   
        }
    }
}