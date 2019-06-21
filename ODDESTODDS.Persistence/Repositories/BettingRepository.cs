using Microsoft.EntityFrameworkCore;
using ODDESTODDS.Domain.Entity;
using ODDESTODDS.Persistence.Context;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODDESTODDS.Persistence.Repositories
{
    public class BettingRepository : BaseRepository, IBettingRepository
    {
        public BettingRepository(ApplicatioDBContext context) : base(context) { }
        
        public async Task AddAsync(GameInfo game, GameOdd odds)
        {
            var response=await _context.GameInfos.AddAsync(game);
           
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameInfo>> GameListAsync()
        {
            return await _context.GameInfos.Include(p=>p.GameOdd).AsNoTracking().ToListAsync();
        }
    }
}
