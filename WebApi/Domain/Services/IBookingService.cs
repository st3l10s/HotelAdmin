using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync();
        Task<BookingResponse> SaveAsync(Booking booking);
        Task<BookingResponse> UpdateAsync(int id, Booking booking);
        Task<BookingResponse> DeleteAsync(int id);
        Task<BookingResponse> FindByIdAsync(int id);
    }
}
