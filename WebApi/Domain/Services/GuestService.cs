using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GuestService(IGuestRepository guestRepository, IUnitOfWork unitOfWork)
        {
            _guestRepository = guestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GuestResponse> DeleteAsync(int id)
        {
            var existingGuest = await _guestRepository.FindByIdAsync(id);
            
            if (existingGuest == null)
            {
                return new GuestResponse("Guest not found");
            }
            
            try
            {
                _guestRepository.Remove(existingGuest);
                await _unitOfWork.CompleteAsync();
                
                return new GuestResponse(existingGuest);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new GuestResponse("An error ocurred while deleting the Guest: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }

        }

        public async Task<GuestResponse> FindByIdAsync(int id)
        {
            var existingGuest = await _guestRepository.FindByIdAsync(id);

            if (existingGuest == null)
            {
                return new GuestResponse("Guest not found");
            }

            return new GuestResponse(existingGuest);
        }

        public async Task<IEnumerable<Guest>> ListAsync()
        {
            var guests = await _guestRepository.ListAsync();

            return guests;
        }

        public async Task<GuestResponse> SaveAsync(Guest guest)
        {
            try
            {
                await _guestRepository.AddAsync(guest);
                await _unitOfWork.CompleteAsync();

                return new GuestResponse(guest);
            }
            catch(Exception e)
            {
                //TODO - Log the exception
                return new GuestResponse("An error ocurred while saving the Guest: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<GuestResponse> UpdateAsync(int id, Guest guest)
        {
            var existingGuest = await _guestRepository.FindByIdAsync(id);

            if (existingGuest == null)
            {
                return new GuestResponse("Guest not found");
            }

            existingGuest.Name = guest.Name;
            existingGuest.LastName = guest.LastName;
            existingGuest.BirthDay = guest.BirthDay;
            existingGuest.Document = guest.Document;
            existingGuest.Email = guest.Email;
            existingGuest.PhoneNumber = guest.PhoneNumber;
            existingGuest.DocumentTypeID = guest.DocumentTypeID;
            existingGuest.GenderID = guest.GenderID;
            existingGuest.BookingID = guest.BookingID;

            try
            {
                _guestRepository.Update(guest);
                await _unitOfWork.CompleteAsync();
                return new GuestResponse(guest);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new GuestResponse("An error ocurred while updating the Guest " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }
    }
}
