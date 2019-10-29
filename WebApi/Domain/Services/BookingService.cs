using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingRoomRepository _bookingRoomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IBookingRoomRepository bookingRoomRepository)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _bookingRoomRepository = bookingRoomRepository;
        }
        public async Task<BookingResponse> DeleteAsync(int id)
        {
            var existingBooking = await _bookingRepository.FindByIdAsync(id);

            if (existingBooking == null)
            {
                return new BookingResponse("Booking not found");
            }

            try
            {
                _bookingRepository.Remove(existingBooking);
                await _unitOfWork.CompleteAsync();

                return new BookingResponse(existingBooking);
            }
            catch (Exception e)
            {
                //TODO - log the exception
                return new BookingResponse($"An error ocurred while deleting the Booking: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<BookingResponse> FindByIdAsync(int id)
        {
            var existingBooking = await _bookingRepository.FindByIdAsync(id);

            if (existingBooking == null)
            {
                return new BookingResponse("Booking not found");
            }

            return new BookingResponse(existingBooking);
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            var bookings = await _bookingRepository.ListAsync();

            foreach (Booking booking in bookings)
            {
                booking.Rooms = await _bookingRoomRepository.ListByBookingID(booking.ID);
            }

            return bookings;
        }

        public async Task<BookingResponse> SaveAsync(Booking booking)
        {
            int inexistentRoomID = await RoomsExist(booking.Rooms);
            if (inexistentRoomID != int.MinValue)
            {
                return new BookingResponse($"Room ID:{ inexistentRoomID } does not exist");
            }

            try
            {
                await _bookingRepository.AddAsync(booking);
                await _unitOfWork.CompleteAsync();

                booking.Rooms = await _bookingRoomRepository.ListByBookingID(booking.ID);

                return new BookingResponse(booking);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new BookingResponse("An error ocurred while saving the Booking: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        public async Task<BookingResponse> UpdateAsync(int id, Booking booking)
        {
            var existingBooking = await _bookingRepository.FindByIdAsync(id);

            if (existingBooking == null)
            {
                return new BookingResponse("Booking not found");
            }

            int inexistentRoomID = await RoomsExist(booking.Rooms);
            if (inexistentRoomID != int.MinValue)
            {
                return new BookingResponse($"Room ID:{ inexistentRoomID } does not exist");
            }

            existingBooking.CheckIn = booking.CheckIn;
            existingBooking.CheckOut = booking.CheckOut;
            existingBooking.GuestsQuantity = booking.GuestsQuantity;
            //existingBooking.RoomID = booking.RoomID;

            try
            {
                _bookingRepository.Update(existingBooking);
                await _unitOfWork.CompleteAsync();

                return new BookingResponse(existingBooking);
            }
            catch (Exception e)
            {
                //TODO - log the exception
                return new BookingResponse($"An error ocurred while updating the Booking: " +
                    $"{ e.Message } { e.InnerException?.Message }");
            }
        }

        private async Task<int> RoomsExist(IList<BookingRoom> rooms)
        {
            foreach (BookingRoom room in rooms)
            {
                if (!await _bookingRepository.RoomExists(room.RoomID))
                {
                    return room.RoomID;
                }
            }

            return int.MinValue;
        }
    }
}
