using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class SaveHotelResponse : BaseResponse
    {
        public Hotel Hotel { get; private set; }

        private SaveHotelResponse(bool success, string message, Hotel hotel) : base(success, message)
        {

        }

        public SaveHotelResponse(Hotel hotel) : this(true, string.Empty, hotel)
        {

        }

        public SaveHotelResponse(string message) : this(false, message, null)
        {

        }
    }
}
