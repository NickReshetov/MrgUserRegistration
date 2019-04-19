using System;

namespace MrgUserRegistration.Services.Exceptions
{
    public class CreateCustomerException : Exception
    {
        public CreateCustomerException(string message) : base(message)
        {
        }
    }
}
