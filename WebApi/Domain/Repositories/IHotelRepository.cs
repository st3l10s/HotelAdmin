using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> ListAsync();
        Task AddAsync(Hotel hotel);
        Task<Hotel> FindByIdAsync(int id);
        void Update(Hotel hotel);
        void Remove(Hotel hotel);
    }
}
