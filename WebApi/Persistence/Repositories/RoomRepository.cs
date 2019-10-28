using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Persistence.Contexts;

namespace WebApi.Persistence.Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(HotelAdminContext context) : base(context)
        {

        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            room.RoomType = await _context.RoomTypes.FindAsync(room.RoomTypeID);
        }

        public async Task<Room> FindByIdAsync(int id)
        {
            var room = await _context.Rooms
                .Include(t => t.RoomType)
                .FirstOrDefaultAsync(x => x.ID == id);

            return room;
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            var rooms = await _context.Rooms
                .Include(t => t.RoomType)
                .ToListAsync();

            return rooms;
        }

        public void Remove(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public void Update(Room room)
        {
            _context.Update(room);
            room.RoomType = _context.RoomTypes.Find(room.RoomTypeID);
        }

        public async Task<bool> RoomTypeExists(int id)
        {
            return await _context.RoomTypes.AnyAsync(x => x.ID == id);
        }

        public async Task<bool> HotelExists(int id)
        {
            return await _context.Hotels.AnyAsync(x => x.ID == id);
        }
    }
}
