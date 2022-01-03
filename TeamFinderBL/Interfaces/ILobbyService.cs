using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderDAL.Entities;

namespace TeamFinderBL.Interfaces
{
    public interface ILobbyService
    {
        public int CreateLobby(Lobby lobby);
        public Task<IEnumerable<Lobby>> GetAllLobbies();
        public Task<int> DeleteLobby(int id);
        public void UpdateLobby(int id, Lobby lobby);
        public Task<Lobby> GetLobbyById(int id);
    }
}