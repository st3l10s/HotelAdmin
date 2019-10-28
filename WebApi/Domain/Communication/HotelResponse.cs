using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class HotelResponse : BaseResponse
    {
        public Hotel Hotel { get; private set; }

        private HotelResponse(bool success, string message, Hotel hotel) : base(success, message)
        {
            Hotel = hotel;
        }

        /// <summary>
        /// Creates a success HotelResponse
        /// </summary>
        /// <param name="hotel"></param>
        public HotelResponse(Hotel hotel) : this(true, string.Empty, hotel)
        {

        }

        /// <summary>
        /// Creates an error HotelResponse
        /// </summary>
        /// <param name="message"></param>
        public HotelResponse(string message) : this(false, message, null)
        {

        }
    }
}
