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
        IList<Room> Rooms { get; set; } = new List<Room>();
        public bool Enabled { get; set; } = true;
    }
}
