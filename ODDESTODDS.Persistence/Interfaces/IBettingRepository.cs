using ODDESTODDS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODDESTODDS.Persistence.Interfaces
{
    public interface IBettingRepository
    {
        Task<IEnumerable<GameInfo>> GameListAsync();
        Task AddGameAsync(GameInfo model);

        Task<GameInfo> FindGameByIdAsync(long Id);
        Task<GameOdd> FindGameOddByIdAsync(long Id);
        GameInfo UpdateGame(GameInfo model);
        void RemoveGame(GameInfo model);
        void RemoveOdd(GameOdd model);
    }
}
