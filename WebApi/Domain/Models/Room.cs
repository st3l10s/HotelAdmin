using System.Collections.Generic;

namespace WebApi.Domain.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public bool? Enabled { get; set; }

        public int? HotelID { get; set; }
        public Hotel Hotel { get; set; }

        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        public IList<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}