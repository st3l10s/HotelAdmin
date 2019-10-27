using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Services;
using WebApi.Resources;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomResource>> GetRooms()
        {
            var rooms = await _roomService.ListAsync();
            var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
            return roomResources;
        }
    }
}
