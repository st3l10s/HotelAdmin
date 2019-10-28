using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class GuestResponse : BaseResponse
    {
        public Guest Guest { get; private set; }
        private GuestResponse(bool success, string message, Guest guest) : base(success, message)
        {
            Guest = guest;
        }

        /// <summary>
        /// Creates a success GuestResponse
        /// </summary>
        /// <param name="guest"></param>
        public GuestResponse(Guest guest) : this(true, string.Empty, guest)
        {

        }

        /// <summary>
        /// Creates an error GuestResponse
        /// </summary>
        /// <param name="errorMessage"></param>
        public GuestResponse(string errorMessage) : this(false, errorMessage, null)
        {

        }
    }
}
