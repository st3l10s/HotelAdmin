using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class SaveRoomResource
    {
        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public decimal? Tax { get; set; }
        [Required]
        public int? Floor { get; set; }
        [Required]
        public int? Door { get; set; }
        [Required]
        public bool? Enabled { get; set; } = true;
        public int? HotelID { get; set; }
        [Required]
        public int? RoomTypeID { get; set; }
    }
}   
