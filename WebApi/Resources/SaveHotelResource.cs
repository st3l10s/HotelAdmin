using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Resources
{
    public class SaveHotelResource
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public bool? Enabled { get; set; } = true;
        [Required]
        public int CityID { get; set; }
    }
}
