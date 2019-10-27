﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Resources
{
    public class RoomResource
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public bool Enabled { get; set; }
        public RoomType RoomType { get; set; }
        //public HotelResource Hotel { get; set; }
    }
}
