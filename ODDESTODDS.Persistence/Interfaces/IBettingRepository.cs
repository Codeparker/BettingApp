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
        Task AddAsync(GameInfo model);
        //Task<GameInfo> FindByIdAsync(int id);
        //void Update(Product product);
        //void Remove(Product product);
    }
}
