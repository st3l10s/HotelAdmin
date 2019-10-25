using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Persistence.Contexts;

namespace WebApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly HotelAdminContext _context;

        public BaseRepository(HotelAdminContext context)
        {
            _context = context;
        }
    }
}
