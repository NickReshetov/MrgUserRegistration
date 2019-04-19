using System;

namespace MrgUserRegistration.Services.Exceptions
{
    public class UpdateCustomerException : Exception
    {
        public UpdateCustomerException(string message) : base(message)
        {
        }
    }
}
