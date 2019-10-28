using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public IList<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
