using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class DisplayHotelResource
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public IList<DisplayRoomMinResource> Rooms { get; set; } = new List<DisplayRoomMinResource>();
    }
}
