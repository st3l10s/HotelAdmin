using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestsQuantity { get; set; }

        public EmergencyContact EmergencyContact { get; set; }

        public IList<Guest> Guests { get; set; } = new List<Guest>();
        public IList<BookingRoom> Rooms { get; set; } = new List<BookingRoom>();
    }
}
