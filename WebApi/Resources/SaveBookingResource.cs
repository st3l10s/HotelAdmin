using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Resources
{
    public class SaveBookingResource
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public int? GuestsQuantity { get; set; }

        [Required]
        public IList<SaveBookingRoomResource> Rooms { get; set; } = new List<SaveBookingRoomResource>();
    }
}
