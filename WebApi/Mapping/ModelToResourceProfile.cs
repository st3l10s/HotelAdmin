using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Resources;

namespace WebApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Hotel, DisplayHotelResource>();
            CreateMap<Room, DisplayRoomResource>();
            CreateMap<Room, DisplayRoomMinResource>();
            CreateMap<RoomType, RoomTypeResource>();
            CreateMap<City, CityResource>();
            CreateMap<Booking, DisplayBookingResource>();
            CreateMap<Guest, DisplayGuestResource>();
            CreateMap<Guest, DisplayGuestMinResource>();
        }
    }
}
