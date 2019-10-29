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
    public class BookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;

        public BookingsController(IMapper mapper, IBookingService bookingService)
        {
            _mapper = mapper;
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IEnumerable<DisplayBookingResource>> GetBookings()
        {
            var bookings = await _bookingService.ListAsync();
            var bookingResources = _mapper.Map<IEnumerable<Booking>, IEnumerable<DisplayBookingResource>>(bookings);
            return bookingResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayBookingResource>> GetBooking(int id)
        {
            var result = await _bookingService.FindByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return _mapper.Map<Booking, DisplayBookingResource>(result.Booking);
        }

        [HttpPost]
        public async Task<ActionResult<DisplayBookingResource>> PostBooking(SaveBookingResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var booking = _mapper.Map<SaveBookingResource, Booking>(resource);
            var result = await _bookingService.SaveAsync(booking);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var bookingResource = _mapper.Map<Booking, DisplayBookingResource>(result.Booking);

            return CreatedAtAction("GetBooking", new { id = bookingResource.ID }, bookingResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisplayBookingResource>> PutBooking(int id, SaveBookingResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var booking = _mapper.Map<SaveBookingResource, Booking>(resource);
            var result = await _bookingService.UpdateAsync(id, booking);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var bookingResource = _mapper.Map<Booking, DisplayBookingResource>(result.Booking);

            return bookingResource;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DisplayBookingResource>> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var bookingResource = _mapper.Map<Booking, DisplayBookingResource>(result.Booking);

            return bookingResource;
        }
    }
}
