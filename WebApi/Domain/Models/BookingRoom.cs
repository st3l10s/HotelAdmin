using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class BookingRoom
    {
        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
