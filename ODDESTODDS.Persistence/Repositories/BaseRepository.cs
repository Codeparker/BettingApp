using ODDESTODDS.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicatioDBContext _context;

        public BaseRepository(ApplicatioDBContext context)
        {
            _context = context;
        }
    }
}
