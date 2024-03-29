﻿using System.Collections.Generic;

namespace WebApi.Domain.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int GuestsCapacity { get; set; }
        public IList<Room> Rooms { get; set; } = new List<Room>();
    }
}
