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
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;

        public GuestsController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DisplayGuestResource>> GetGuests()
        {
            var Guests = await _guestService.ListAsync();
            var GuestResources = _mapper.Map<IEnumerable<Guest>, IEnumerable<DisplayGuestResource>>(Guests);
            return GuestResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayGuestResource>> GetGuest(int id)
        {
            var result = await _guestService.FindByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return _mapper.Map<Guest, DisplayGuestResource>(result.Guest);
        }

        [HttpPost]
        public async Task<ActionResult<DisplayGuestResource>> PostGuest(SaveGuestResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var Guest = _mapper.Map<SaveGuestResource, Guest>(resource);
            var result = await _guestService.SaveAsync(Guest);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var GuestResource = _mapper.Map<Guest, DisplayGuestResource>(result.Guest);

            return CreatedAtAction("GetGuest", new { id = GuestResource.ID }, GuestResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisplayGuestResource>> PutGuest(int id, SaveGuestResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var Guest = _mapper.Map<SaveGuestResource, Guest>(resource);
            var result = await _guestService.UpdateAsync(id, Guest);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var GuestResource = _mapper.Map<Guest, DisplayGuestResource>(result.Guest);

            return GuestResource;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DisplayGuestResource>> DeleteGuest(int id)
        {
            var result = await _guestService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var GuestResource = _mapper.Map<Guest, DisplayGuestResource>(result.Guest);

            return GuestResource;
        }
    }
}
