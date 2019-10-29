using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class BookingResponse : BaseResponse
    {
        public Booking Booking { get; private set; }

        private BookingResponse(bool success, string message, Booking booking) : base(success, message)
        {
            Booking = booking;
        }

        /// <summary>
        /// Creates a success BookingResponse
        /// </summary>
        /// <param name="booking"></param>
        public BookingResponse(Booking booking) : this(true, string.Empty, booking)
        {

        }

        /// <summary>
        /// Creates an error BookingResponse
        /// </summary>
        /// <param name="errorMessage"></param>
        public BookingResponse(string errorMessage) : this(false, errorMessage, null)
        {

        }
    }
}
