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
    public class EmergencyContactsController : ControllerBase
    {
        private readonly IEmergencyContactService _emergencyContactService;
        private readonly IMapper _mapper;

        public EmergencyContactsController(IEmergencyContactService emergencyContactService, IMapper mapper)
        {
            _emergencyContactService = emergencyContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DisplayEmergencyContactResource>> GetEmergencyContacts()
        {
            var rooms = await _emergencyContactService.ListAsync();
            var roomResources = _mapper.Map<IEnumerable<EmergencyContact>, IEnumerable<DisplayEmergencyContactResource>>(rooms);
            return roomResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayEmergencyContactResource>> GetEmergencyContact(int id)
        {
            var result = await _emergencyContactService.FindByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return _mapper.Map<EmergencyContact, DisplayEmergencyContactResource>(result.EmergencyContact);
        }

        [HttpPost]
        public async Task<ActionResult<DisplayEmergencyContactResource>> PostEmergencyContact(
            SaveEmergencyContactResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _mapper.Map<SaveEmergencyContactResource, EmergencyContact>(resource);
            var result = await _emergencyContactService.SaveAsync(room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<EmergencyContact, DisplayEmergencyContactResource>(result.EmergencyContact);

            return CreatedAtAction("GetEmergencyContact", new { id = roomResource.ID }, roomResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisplayEmergencyContactResource>> PutEmergencyContact(int id, 
            SaveEmergencyContactResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _mapper.Map<SaveEmergencyContactResource, EmergencyContact>(resource);
            var result = await _emergencyContactService.UpdateAsync(id, room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<EmergencyContact, DisplayEmergencyContactResource>(result.EmergencyContact);

            return roomResource;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DisplayEmergencyContactResource>> DeleteEmergencyContact(int id)
        {
            var result = await _emergencyContactService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResource = _mapper.Map<EmergencyContact, DisplayEmergencyContactResource>(result.EmergencyContact);

            return roomResource;
        }
    }
}
