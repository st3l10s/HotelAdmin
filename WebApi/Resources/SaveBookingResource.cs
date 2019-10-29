using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public int? RoomID { get; set; }
    }
}
