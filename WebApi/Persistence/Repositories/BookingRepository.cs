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
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(HotelAdminContext context) : base(context)
        {

        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            booking.Room = await _context.Rooms.FindAsync(booking.RoomID);
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await _context.Bookings
                .Include(r => r.Guests)
                .Include(r => r.Room)
                .ToListAsync();
        }

        public async Task<Booking> FindByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(r => r.Room)
                .Include(r => r.Guests)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public void Update(Booking booking)
        {
            _context.Update(booking);
            booking.Room = _context.Rooms.Find(booking.RoomID);
        }

        public void Remove(Booking booking)
        {
            _context.Remove(booking);
        }

        public async Task<bool> RoomExists(int id)
        {
            return await _context.Rooms.AnyAsync(x => x.ID == id);
        }
    }
}
