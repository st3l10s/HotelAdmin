using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Communication;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomResponse> DeleteAsync(int id)
        {
            var existingRoom = await _roomRepository.FindByIdAsync(id);

            if (existingRoom == null)
            {
                return new RoomResponse("Room not found");
            }

            try
            {
                _roomRepository.Remove(existingRoom);
                await _unitOfWork.CompleteAsync();

                return new RoomResponse(existingRoom);
            }
            catch (Exception e)
            {
                //TODO - Log the exception
                return new RoomResponse($"An error ocurred while deleting the room: { e.Message }");
            }
        }

        public async Task<RoomResponse> FindByIdAsync(int id)
        {
            var existingRoom = await _roomRepository.FindByIdAsync(id);

            if (existingRoom == null)
            {
                return new RoomResponse("Room not found");
            }

            return new RoomResponse(existingRoom);
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            var rooms = await _roomRepository.ListAsync();
            return rooms;
        }

        public async Task<RoomResponse> SaveAsync(Room room)
        {
            try
            {
                await _roomRepository.AddAsync(room);
                await _unitOfWork.CompleteAsync();

                return new RoomResponse(room);
            }
            catch(Exception e)
            {
                //TODO - Log the exception
                return new RoomResponse($"An error ocurred while saving the room: { e.Message }");
            }
        }

        public async Task<RoomResponse> UpdateAsync(int id, Room room)
        {
            var existingRoom = await _roomRepository.FindByIdAsync(id);
            
            if (existingRoom == null)
            {
                return new RoomResponse("Room not found");
            }

            existingRoom.Door = room.Door;
            existingRoom.Enabled = room.Enabled;
            existingRoom.Floor = room.Floor;
            existingRoom.Hotel = room.Hotel;
            existingRoom.Price = room.Price;
            existingRoom.Tax = room.Tax;
            existingRoom.Type = room.Type;

            try
            {
                _roomRepository.Update(existingRoom);
                await _unitOfWork.CompleteAsync();

                return new RoomResponse(existingRoom);
            }
            catch(Exception e)
            {
                //TODO - Log the exception
                return new RoomResponse($"An error ocurred while updating the room: { e.Message }");
            }
        }
    }
}
