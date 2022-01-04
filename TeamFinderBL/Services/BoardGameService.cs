using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;

namespace TeamFinderBL.Services
{
    public class BoardGameService : IBoardGameService
    {
        public int Create(BoardGame entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BoardGame>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(BoardGame entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<BoardGame> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}