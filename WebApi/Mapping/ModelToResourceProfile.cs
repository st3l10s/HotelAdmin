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
            CreateMap<Hotel, HotelResource>();
            CreateMap<Room, RoomResource>();
        }
    }
}
