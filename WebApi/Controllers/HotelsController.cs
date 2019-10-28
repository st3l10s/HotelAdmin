    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;
using WebApi.Domain.Services;
using WebApi.Extensions;
using WebApi.Persistence.Contexts;
using WebApi.Resources;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelAdminContext _context;
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(HotelAdminContext context, IHotelService hotelService, IMapper mapper)
        {
            _context = context;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<IEnumerable<DisplayHotelResource>> GetHotels()
        {
            var hotels = await _hotelService.ListAsync();
            var hotelResources = _mapper.Map<IEnumerable<Hotel>, IEnumerable<DisplayHotelResource>>(hotels);
            return hotelResources;
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayHotelResource>> GetHotel(int id)
        {
            var result = await _hotelService.FindByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            var hotelResource = _mapper.Map<Hotel, DisplayHotelResource>(result.Hotel);

            return hotelResource;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<DisplayHotelResource>> PutHotel(int id, SaveHotelResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
            var result = await _hotelService.UpdateAsync(id, hotel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var hotelResource = _mapper.Map<Hotel, DisplayHotelResource>(result.Hotel);

            return hotelResource;
        }

        // POST: api/Hotels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DisplayHotelResource>> PostHotel(SaveHotelResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
            var result = await _hotelService.SaveAsync(hotel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var hotelResource = _mapper.Map<Hotel, DisplayHotelResource>(result.Hotel);

            return CreatedAtAction("GetHotel", new { id = hotelResource.ID }, hotelResource);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DisplayHotelResource>> DeleteHotel(int id)
        {
            var result = await _hotelService.DeleteAsync(id);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var hotelResource = _mapper.Map<Hotel, DisplayHotelResource>(result.Hotel);

            return hotelResource;
        }
    }
}
