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
        public async Task<IEnumerable<HotelResource>> GetHotels()
        {
            var hotels = await _hotelService.ListAsync();

            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelResource>>(hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(SaveHotelResource resource)
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

            var hotelResource = _mapper.Map<Hotel, HotelResource>(result.Hotel);

            return CreatedAtAction("GetHotel", new { id = hotelResource.ID }, hotelResource);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.ID == id);
        }
    }
}
