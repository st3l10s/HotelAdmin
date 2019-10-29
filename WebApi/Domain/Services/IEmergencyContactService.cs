using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IEmergencyContactService
    {
        Task<EmergencyContactResponse> DeleteAsync(int id);
        Task<EmergencyContactResponse> FindByIdAsync(int id);
        Task<IEnumerable<EmergencyContact>> ListAsync();
        Task<EmergencyContactResponse> SaveAsync(EmergencyContact emergencyContact);
        Task<EmergencyContactResponse> UpdateAsync(int id, EmergencyContact emergencyContact);
    }
}