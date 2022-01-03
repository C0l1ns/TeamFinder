﻿using System.Collections;
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
        private readonly ILobbyRepository _lobbyRepository;
        private readonly IBoardGameRepository _boardGameRepository;

        public LobbyController(ILobbyRepository lobbyRepository, IBoardGameRepository boardGameRepository)
        {
            _lobbyRepository = lobbyRepository;
            _boardGameRepository = boardGameRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Lobby> lobbyList = await _lobbyRepository.GetAll();

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
            obj.Lobby.HostId = 1; // TODO: забрати цей лютий кастиль коли буде авторизація

            if (ModelState.IsValid)
            {
                _lobbyRepository.Create(obj.Lobby);
                _lobbyRepository.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}