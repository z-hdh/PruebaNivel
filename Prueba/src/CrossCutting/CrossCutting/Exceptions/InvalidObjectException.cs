using System;

namespace CrossCutting.Exceptions
{
    public class InvalidObjectException : Exception
    {
        public string Code { get; set; }

        public InvalidObjectException(string code, string message) : base(message)
        {
            Code = code;
        }

        public InvalidObjectException(string code, string message, Exception ex) : base(message, ex)
        {
            Code = code;
        }
    }
}
