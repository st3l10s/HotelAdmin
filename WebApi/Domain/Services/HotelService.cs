using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Hotel>> ListAsync()
        {
            var hotels = _hotelRepository.ListAsync();
            return hotels;
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            try
            {
                await _hotelRepository.AddAsync(hotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(hotel);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new HotelResponse($"An error ocurred while saving the Hotel: { e.Message }");
            }
        }

        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found");
            }

            existingHotel.Description = hotel.Description;

            try
            {
                _hotelRepository.Update(existingHotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(existingHotel);
            }
            catch(Exception e)
            {
                //TODO - log the exception
                return new HotelResponse($"An error ocurred while updating the hotel: { e.Message }");
            }
        }

        public async Task<HotelResponse> DeleteAsync(int id)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found");
            }

            try
            {
                _hotelRepository.Remove(existingHotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(existingHotel);
            }
            catch (Exception e)
            {
                return new HotelResponse($"An error ocurred while deleting the hotel: { e.Message }");
            }
        }

        public async Task<HotelResponse> FindByIdAsync(int id)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found");
            }

            return new HotelResponse(existingHotel);
        }
    }
}
