using System;

namespace MrgUserRegistration.Services.Exceptions
{
    public class GetCustomersException : Exception
    {
        public GetCustomersException(string message) : base(message)
        {
        }
    }
}
