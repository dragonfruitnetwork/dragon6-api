using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon6.API.Exceptions
{
    class TokenInvalidException : Exception
    {
        public TokenInvalidException(){}
        public TokenInvalidException(string Message):base(Message){}
        public TokenInvalidException(string message, Exception inner) : base(message, inner){}
    }
}
