using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class InvalidCreatureException :ApplicationException
    {

        public InvalidCreatureException(string message)
            : base(message)
        { }

        public InvalidCreatureException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
