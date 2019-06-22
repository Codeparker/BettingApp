using Microsoft.EntityFrameworkCore;
using ODDESTODDS.Domain.Entity;
using ODDESTODDS.Persistence.Context;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODDESTODDS.Persistence.Repositories
{
    public class BettingRepository : BaseRepository, IBettingRepository
    {
        public BettingRepository(ApplicatioDBContext context) : base(context) { }
        
        public async Task AddGameAsync(GameInfo model)
        {
           await _context.GameInfos.AddAsync(model);
        }

        public async Task<GameInfo> FindGameByIdAsync(long Id)
        {
            return await _context.GameInfos.Include(p => p.GameOdd).AsNoTracking().FirstOrDefaultAsync(c=>c.Id==Id);
        }

        public async Task<GameOdd> FindGameOddByIdAsync(long Id)
        {
            return await _context.GameOdds.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<GameInfo>> GameListAsync()
        {
            return await _context.GameInfos.Include(p=>p.GameOdd).AsNoTracking().ToListAsync();
        }

        public void RemoveGame(GameInfo model)
        {
           _context.GameInfos.Remove(model);
        }

        public void RemoveOdd(GameOdd model)
        {

            model.ModifiedDate = DateTime.Now;
            _context.GameOdds.Update(model);
        }

        public GameInfo UpdateGame(GameInfo model)
        {
            model.ModifiedDate = DateTime.Now;
            _context.GameInfos.Update(model);
            return model;
        }
    }
}
