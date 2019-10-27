using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class HotelResource
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public IList<RoomResource> Rooms { get; set; } = new List<RoomResource>();
    }
}
