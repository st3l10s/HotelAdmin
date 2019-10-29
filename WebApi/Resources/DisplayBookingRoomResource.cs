using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class DisplayBookingRoomResource
    {
        public int RoomID { get; set; }
        public int BookingID { get; set; }
        public DisplayRoomMinResource Room { get; set; }
    }
}
