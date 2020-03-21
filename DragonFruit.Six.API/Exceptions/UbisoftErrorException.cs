using System;

namespace DragonFruit.Six.API.Exceptions
{
    public class UbisoftErrorException : Exception
    {
        public UbisoftErrorException()
            : base("A Ubisoft server has disallowed this request, probably due to the Ubi-AppId header. Please check and try again")
        {
        }
    }
}
