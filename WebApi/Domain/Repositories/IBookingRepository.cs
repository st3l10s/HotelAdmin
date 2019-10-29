using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();
        Task AddAsync(Booking hotel);
        Task<Booking> FindByIdAsync(int id);
        void Update(Booking hotel);
        void Remove(Booking hotel);
        Task<bool> RoomExists(int id);
    }
}
