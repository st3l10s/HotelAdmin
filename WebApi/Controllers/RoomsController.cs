using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Services;
using WebApi.Extensions;
using WebApi.Resources;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
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
        public async Task<IEnumerable<DisplayRoomResource>> GetRooms()
        {
            var rooms = await _roomService.ListAsync();
            var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<DisplayRoomResource>>(rooms);
            return roomResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayRoomResource>> GetRoom(int id)
        {
            var result = await _roomService.FindByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return _mapper.Map<Room, DisplayRoomResource>(result.Room);
        }

        [HttpPost]
        public async Task<ActionResult<DisplayRoomResource>> PostRoom(SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.SaveAsync(room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<Room, DisplayRoomResource>(result.Room);

            return CreatedAtAction("GetRoom", new { id = roomResource.ID }, roomResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisplayRoomResource>> PutRoom(int id, SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.UpdateAsync(id, room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<Room, DisplayRoomResource>(result.Room);

            return roomResource;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DisplayRoomResource>> DeleteRoom(int id)
        {
            var result = await _roomService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<Room, DisplayRoomResource>(result.Room);

            return roomResource;
        }
    }
}
