using ODDESTODDS.Domain.Entity;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODDESTODDS.Persistence.Repositories
{
    public class MockBettingRepository : IBettingRepository
    {
        public async Task AddGameAsync(GameInfo model)
        {
            throw new NotImplementedException();
        }

        public async Task<GameInfo> FindGameByIdAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameOdd> FindGameOddByIdAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameInfo>> GameListAsync()
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(GameInfo model)
        {
            throw new NotImplementedException();
        }

        public void RemoveOdd(GameOdd model)
        {
            throw new NotImplementedException();
        }

        public GameInfo UpdateGame(GameInfo model)
        {
            throw new NotImplementedException();
        }
    }
}
