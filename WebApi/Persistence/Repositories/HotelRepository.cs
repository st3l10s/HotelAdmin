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

        public async Task AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public void Update(Hotel hotel)
        {
            _context.Update(hotel);
        }

        public void Remove(Hotel hotel)
        {
            _context.Remove(hotel);
        }
    }
}
