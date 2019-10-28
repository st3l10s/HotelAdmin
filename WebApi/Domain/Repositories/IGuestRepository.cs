using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> FindByIdAsync(int id);
        Task<IEnumerable<Guest>> ListAsync();
        Task AddAsync(Guest guest);
        void Update(Guest guest);
        void Remove(Guest guest);
        Task<bool> DocumentTypeExists(int id);
        Task<bool> GenderExists(int id);
        Task<bool> BookingExists(int id);
    }
}
