using System;

namespace Challenges.Common.Exceptions.WebServices
{
    public class WebServiceException : Exception
    {
        public WebServiceException(string message) : base(message) { }
    }
}