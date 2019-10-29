using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class DisplayBookingResource
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestsQuantity { get; set; }
        public DisplayEmergencyContactResource EmergencyContact { get; set; }
        public IList<DisplayGuestMinResource> Guests { get; set; } = new List<DisplayGuestMinResource>();
        public IList<DisplayBookingRoomResource> Rooms { get; set; } = new List<DisplayBookingRoomResource>();
    }
}
