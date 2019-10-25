using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync();
        Task<SaveHotelResponse> SaveAsync(Hotel hotel);
    }
}
