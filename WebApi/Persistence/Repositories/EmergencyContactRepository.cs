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
    public class EmergencyContactRepository : BaseRepository, IEmergencyContactRepository
    {
        public EmergencyContactRepository(HotelAdminContext context) : base(context)
        {

        }

        public async Task AddAsync(EmergencyContact emergencyContact)
        {
            await _context.EmergencyContacts.AddAsync(emergencyContact);
            emergencyContact.Booking = await _context.Bookings.FindAsync(emergencyContact.BookingID);
        }

        public async Task<EmergencyContact> FindByIdAsync(int id)
        {
            var emergencyContact = await _context.EmergencyContacts
                .Include(t => t.Booking)
                .FirstOrDefaultAsync(x => x.BookingID == id);

            return emergencyContact;
        }

        public async Task<IEnumerable<EmergencyContact>> ListAsync()
        {
            var emergencyContacts = await _context.EmergencyContacts
                .Include(t => t.Booking)
                .ToListAsync();

            return emergencyContacts;
        }

        public void Remove(EmergencyContact emergencyContact)
        {
            _context.EmergencyContacts.Remove(emergencyContact);
        }

        public void Update(EmergencyContact emergencyContact)
        {
            _context.Update(emergencyContact);
            emergencyContact.Booking = _context.Bookings.Find(emergencyContact.BookingID);
        }

        public async Task<bool> BookingExists(int id)
        {
            return await _context.Bookings.AnyAsync(x => x.ID == id);
        }
    }
}
