using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly Project1Context _context;

        public BaseRepository(Project1Context context)
        {
            _context = context;
        }
    }
}
