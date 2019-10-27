using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync();
        Task<RoomResponse> FindByIdAsync(int id);
        Task<RoomResponse> SaveAsync(Room room);
        Task<RoomResponse> UpdateAsync(int id, Room room);
        Task<RoomResponse> DeleteAsync(int id);
    }
}
