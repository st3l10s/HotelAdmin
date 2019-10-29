using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class DisplayHotelMinResource
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public CityResource City { get; set; }
    }
}
