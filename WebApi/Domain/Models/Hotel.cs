using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }

        public IList<Room> Rooms { get; set; } = new List<Room>();
    }
}
