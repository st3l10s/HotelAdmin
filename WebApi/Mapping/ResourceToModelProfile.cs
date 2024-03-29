﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Resources;

namespace WebApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveHotelResource, Hotel>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveGuestResource, Guest>();
            CreateMap<SaveBookingResource, Booking>();
            CreateMap<SaveEmergencyContactResource, EmergencyContact>();
            CreateMap<SaveBookingRoomResource, BookingRoom>();
        }
    }
}
