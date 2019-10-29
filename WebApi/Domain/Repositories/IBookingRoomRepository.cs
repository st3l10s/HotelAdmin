using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IBookingRoomRepository
    {
        Task<IList<BookingRoom>> ListByBookingID(int bookingID);
    }
}
