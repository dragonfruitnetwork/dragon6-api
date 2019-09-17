using System;

namespace Dragon6.API.Exceptions
{
    internal class TokenInvalidException : Exception
    {
        public TokenInvalidException() { }
        public TokenInvalidException(string Message) : base(Message) { }
        public TokenInvalidException(string message, Exception inner) : base(message, inner) { }
    }
}
