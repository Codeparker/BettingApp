using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODDESTODDS.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
