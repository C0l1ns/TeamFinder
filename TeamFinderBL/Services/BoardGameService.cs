using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderBL.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }
        public int Create(BoardGame boardGame)
        {
            if (boardGame == null)
            {
                throw new NullReferenceException();
            }

            _boardGameRepository.Create(boardGame);
            _boardGameRepository.Save();
            return boardGame.Id;
        }

        public async Task<IEnumerable<BoardGame>> GetAll()
        {
            var boardGames = await _boardGameRepository.GetAll();
            return boardGames;
        }

        public async Task<int> Delete(int id)
        {
            var boardGame = await _boardGameRepository.GetById(id);
            if (boardGame == null)
            {
                throw new NullReferenceException();
            }

            _boardGameRepository.Delete(boardGame);
            _boardGameRepository.Save();
            return boardGame.Id;
        }

        public void Update(BoardGame boardGame)
        {
            _boardGameRepository.Update(boardGame);
            _boardGameRepository.Save();
        }

        public async Task<BoardGame> GetById(int id)
        {
            var boardGame = await _boardGameRepository.GetById(id);
            return boardGame;
        }
    }
}