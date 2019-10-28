using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Guest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        public int BookingID { get; set; }
        public Booking Booking { get; set; }
    }
}
