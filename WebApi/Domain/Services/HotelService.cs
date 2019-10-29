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
        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            var hotels = await _hotelRepository.ListAsync();

            return hotels;
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            hotel.Enabled ??= true;

            var cityExists = await _hotelRepository.CityExists(hotel.CityID);

            if (!cityExists)
            {
                return new HotelResponse($"City ID:{ hotel.CityID } does not exist");
            }

            try
            {
                await _hotelRepository.AddAsync(hotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(hotel);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new HotelResponse("An error ocurred while saving the Hotel: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found");
            }

            var cityExists = await _hotelRepository.CityExists(hotel.CityID);

            if (!cityExists)
            {
                return new HotelResponse($"City ID:{ hotel.CityID } does not exist");
            }

            existingHotel.Description = hotel.Description;
            existingHotel.CityID = hotel.CityID;
            existingHotel.Enabled = hotel.Enabled ?? existingHotel.Enabled;

            try
            {
                _hotelRepository.Update(existingHotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(existingHotel);
            }
            catch(Exception e)
            {
                //TODO - log the exception
                return new HotelResponse($"An error ocurred while updating the Hotel: " +
                    $"{ e.Message } { e.InnerException?.Message }");
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
                //TODO - log the exception
                return new HotelResponse($"An error ocurred while deleting the Hotel: " +
                    $"{ e.Message } { e.InnerException?.Message }");
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
