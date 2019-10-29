using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Communication
{
    public class EmergencyContactResponse : BaseResponse
    {
        public EmergencyContact EmergencyContact { get; set; }

        private EmergencyContactResponse(bool success, string message, EmergencyContact emergencyContact) 
            : base(success, message)
        {
            EmergencyContact = emergencyContact;
        }

        /// <summary>
        /// Creates a success EmergencyContactResponse
        /// </summary>
        /// <param name="emergencyContact"></param>
        public EmergencyContactResponse(EmergencyContact emergencyContact) : this(true, string.Empty, emergencyContact)
        {

        }

        /// <summary>
        /// Creates an error EmergencyContactResponse
        /// </summary>
        /// <param name="errorMessage"></param>
        public EmergencyContactResponse(string errorMessage) : this(false, errorMessage, null)
        {

        }
    }
}
