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
            hotel.City = await _context.Cities.FindAsync(hotel.CityID);
        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await _context.Hotels
                .Include(r => r.Rooms)
                .Include(r => r.City)
                .ToListAsync();
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await _context.Hotels
                .Include(r => r.Rooms)
                .Include(r => r.City)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public void Update(Hotel hotel)
        {
            _context.Update(hotel);
            hotel.City = _context.Cities.Find(hotel.CityID);
        }

        public void Remove(Hotel hotel)
        {
            _context.Remove(hotel);
        }

        public async Task<bool> CityExists(int id)
        {
            return await _context.Cities.AnyAsync(x => x.ID == id);
        }
    }
}
