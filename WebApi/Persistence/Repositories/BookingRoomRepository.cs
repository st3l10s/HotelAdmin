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
    public class BookingRoomRepository : BaseRepository, IBookingRoomRepository
    {
        public BookingRoomRepository(HotelAdminContext context) : base(context)
        {

        }
        public async Task<IList<BookingRoom>> ListByBookingID(int bookingID)
        {
            var bookingRooms = await _context.BookingRooms.Where(x => x.BookingID == bookingID).ToListAsync();

            return bookingRooms;
        }
    }
}
