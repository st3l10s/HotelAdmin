using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class RoomResponse : BaseResponse
    {
        public Room Room { get; private set; }
        private RoomResponse(bool success, string message, Room room) : base(success, message)
        {
            Room = room;
        }

        public RoomResponse(Room room) : this(true, string.Empty, room)
        {

        }

        public RoomResponse(string message) : this(false, message, null)
        {

        }
    }
}
