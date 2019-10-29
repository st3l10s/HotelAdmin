using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IEmergencyContactRepository
    {
        Task<IEnumerable<EmergencyContact>> ListAsync();
        Task AddAsync(EmergencyContact hotel);
        Task<EmergencyContact> FindByIdAsync(int id);
        void Update(EmergencyContact hotel);
        void Remove(EmergencyContact hotel);
        Task<bool> BookingExists(int id);
    }
}
