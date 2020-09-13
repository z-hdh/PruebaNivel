using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Exceptions
{
    public class ArgumentNotValidException : Exception
    {
        public string Code { get; set; }

        public ArgumentNotValidException(string code, string message) : base(message)
        {
            Code = code;
        }

        public ArgumentNotValidException(string code, string message, Exception ex) : base(message, ex)
        {
            Code = code;
        }
    }
}
