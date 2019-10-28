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
    public class GuestRepository : BaseRepository, IGuestRepository
    {

        public GuestRepository(HotelAdminContext context) : base(context)
        {

        }
        public async Task AddAsync(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            guest.Booking = await _context.Bookings.FindAsync(guest.BookingID);
            guest.DocumentType = await _context.DocumentTypes.FindAsync(guest.DocumentTypeID);
            guest.Gender = await _context.Genders.FindAsync(guest.GenderID);
        }

        public async Task<bool> BookingExists(int id)
        {
            return await _context.Bookings.AnyAsync(x => x.ID == id);
        }

        public async Task<bool> DocumentTypeExists(int id)
        {
            return await _context.DocumentTypes.AnyAsync(x => x.ID == id);
        }

        public async Task<Guest> FindByIdAsync(int id)
        {
            var guest = await _context.Guests
                .Include(c => c.Gender)
                .Include(c => c.Booking)
                .Include(c => c.DocumentType)
                .FirstOrDefaultAsync(x => x.ID == id);

            return guest;
        }

        public async Task<bool> GenderExists(int id)
        {
            return await _context.Genders.AnyAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<Guest>> ListAsync()
        {
            var guests = await _context.Guests
                .Include(c => c.Booking)
                .Include(c => c.DocumentType)
                .Include(c => c.Gender)
                .ToListAsync();

            return guests;
        }

        public void Remove(Guest guest)
        {
            _context.Guests.Remove(guest);
        }

        public void Update(Guest guest)
        {
            _context.Update(guest);
        }
    }
}
