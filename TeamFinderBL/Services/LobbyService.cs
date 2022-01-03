using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderBL.Services
{
    public class LobbyService:ILobbyService
    {
        private readonly ILobbyRepository _lobbyRepository;
        public LobbyService(
            ILobbyRepository lobbyRepository)
        {
            _lobbyRepository = lobbyRepository;
        }

        public int CreateLobby(Lobby lobby)
        {
            if (lobby == null)
            {
                throw new NullReferenceException();
            }
            _lobbyRepository.Create(lobby);
            _lobbyRepository.Save();
            return lobby.Id;
        }

        public async Task<IEnumerable<Lobby>> GetAllLobbies()
        {
            var lobbies = await _lobbyRepository.GetAll();
            return lobbies;
        }

        public async Task<int> DeleteLobby(int id)
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

        public void UpdateLobby(int id, Lobby lobby)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Lobby> GetLobbyById(int id)
        {
            var lobby = await _lobbyRepository.GetById(id);
            return lobby;
        }
    }
}