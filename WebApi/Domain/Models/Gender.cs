using System.Collections.Generic;

namespace WebApi.Domain.Models
{
    public class Gender
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public IList<Guest> Guests { get; set; } = new List<Guest>();
    }
}