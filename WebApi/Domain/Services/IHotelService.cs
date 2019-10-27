using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync();
        Task<HotelResponse> SaveAsync(Hotel hotel);
        Task<HotelResponse> UpdateAsync(int id, Hotel hotel);
        Task<HotelResponse> DeleteAsync(int id);
        Task<HotelResponse> FindByIdAsync(int id);
    }
}
