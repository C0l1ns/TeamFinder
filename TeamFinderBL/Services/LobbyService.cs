using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderBL.Services
{
    public class LobbyService : ILobbyService
    {
        private readonly ILobbyRepository _lobbyRepository;


        public LobbyService(
            ILobbyRepository lobbyRepository)
        {
            _lobbyRepository = lobbyRepository;
        }

        public int Create(Lobby lobby)
        {
            if (lobby == null)
            {
                throw new NullReferenceException();
            }

            _lobbyRepository.Create(lobby);
            _lobbyRepository.Save();
            return lobby.Id;
        }

        public async Task<IEnumerable<Lobby>> GetAll()
        {
            var lobbies = await _lobbyRepository.GetAll();
            return lobbies;
        }

        public async Task<int> Delete(int id)
        {
            var lobby = await _lobbyRepository.GetById(id);



            if (lobby == null)
            {
                throw new NullReferenceException();
            }

            _lobbyRepository.Delete(lobby);
            _lobbyRepository.Save();
            return lobby.Id;
        }

        public void Update(Lobby lobby)
        {
            _lobbyRepository.Update(lobby);
            _lobbyRepository.Save();
        }

        public async Task<Lobby> GetById(int id)
        {
            var lobby = await _lobbyRepository.GetById(id);
           
            return lobby;
        }
    }
}