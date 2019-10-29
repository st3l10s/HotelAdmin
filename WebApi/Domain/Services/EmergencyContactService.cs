using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly IEmergencyContactRepository _emergencyContactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmergencyContactService(IEmergencyContactRepository emergencyContactRepository, IUnitOfWork unitOfWork)
        {
            _emergencyContactRepository = emergencyContactRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmergencyContact>> ListAsync()
        {
            var emergencyContacts = await _emergencyContactRepository.ListAsync();
            return emergencyContacts;
        }

        public async Task<EmergencyContactResponse> SaveAsync(EmergencyContact emergencyContact)
        {
            var bookingExists = await _emergencyContactRepository.BookingExists(emergencyContact.BookingID);

            if (!bookingExists)
            {
                return new EmergencyContactResponse($"Booking ID:{ emergencyContact.BookingID } does not exist");
            }

            try
            {
                await _emergencyContactRepository.AddAsync(emergencyContact);
                await _unitOfWork.CompleteAsync();

                return new EmergencyContactResponse(emergencyContact);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new EmergencyContactResponse("An error ocurred while saving the EmergencyContact: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<EmergencyContactResponse> UpdateAsync(int id, EmergencyContact emergencyContact)
        {
            var existingEmergencyContact = await _emergencyContactRepository.FindByIdAsync(id);

            if (existingEmergencyContact == null)
            {
                return new EmergencyContactResponse("EmergencyContact not found");
            }

            var bookingExists = await _emergencyContactRepository.BookingExists(emergencyContact.BookingID);

            if (!bookingExists)
            {
                return new EmergencyContactResponse($"Booking ID:{ emergencyContact.BookingID } does not exist");
            }

            existingEmergencyContact.BookingID = emergencyContact.BookingID;
            existingEmergencyContact.Name = emergencyContact.Name;
            existingEmergencyContact.LastName = emergencyContact.LastName;
            existingEmergencyContact.PhoneNumber = emergencyContact.PhoneNumber;

            try
            {
                _emergencyContactRepository.Update(existingEmergencyContact);
                await _unitOfWork.CompleteAsync();

                return new EmergencyContactResponse(existingEmergencyContact);
            }
            catch (Exception e)
            {
                //TODO - log the exception
                return new EmergencyContactResponse($"An error ocurred while updating the EmergencyContact: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<EmergencyContactResponse> DeleteAsync(int id)
        {
            var existingEmergencyContact = await _emergencyContactRepository.FindByIdAsync(id);

            if (existingEmergencyContact == null)
            {
                return new EmergencyContactResponse("EmergencyContact not found");
            }

            try
            {
                _emergencyContactRepository.Remove(existingEmergencyContact);
                await _unitOfWork.CompleteAsync();

                return new EmergencyContactResponse(existingEmergencyContact);
            }
            catch (Exception e)
            {
                //TODO - log the exception
                return new EmergencyContactResponse($"An error ocurred while deleting the EmergencyContact: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<EmergencyContactResponse> FindByIdAsync(int id)
        {
            var existingEmergencyContact = await _emergencyContactRepository.FindByIdAsync(id);

            if (existingEmergencyContact == null)
            {
                return new EmergencyContactResponse("EmergencyContact not found");
            }

            return new EmergencyContactResponse(existingEmergencyContact);
        }
    }
}
