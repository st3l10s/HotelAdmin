using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> ListAsync();
        Task<GuestResponse> SaveAsync(Guest guest);
        Task<GuestResponse> UpdateAsync(int id, Guest guest);
        Task<GuestResponse> DeleteAsync(int id);
        Task<GuestResponse> FindByIdAsync(int id);
    }
}
