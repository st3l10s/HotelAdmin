using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Persistence.Contexts;

namespace WebApi.Persistence.Repositories
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(HotelAdminContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await _context.Hotels.ToListAsync();
        }
    }
}
