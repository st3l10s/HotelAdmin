using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class RoomTypeResource
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int GuestsCapacity { get; set; }
    }
}
