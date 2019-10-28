using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class DocumentType
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public IList<Guest> Guests { get; set; } = new List<Guest>();
    }
}
