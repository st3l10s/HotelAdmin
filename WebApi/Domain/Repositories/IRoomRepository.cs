using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();
        Task<Room> FindByIdAsync(int id);
        Task AddAsync(Room room);
        void Update(Room room);
        void Remove(Room room);
        Task<bool> RoomTypeExists(int id);
        Task<bool> HotelExists(int id);
    }
}
