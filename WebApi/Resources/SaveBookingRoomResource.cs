using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class SaveBookingRoomResource
    {
        [Required]
        public int? RoomID { get; set; }
    }
}
