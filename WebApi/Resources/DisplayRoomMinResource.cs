using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Resources
{
    public class DisplayRoomMinResource
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
    }
}
