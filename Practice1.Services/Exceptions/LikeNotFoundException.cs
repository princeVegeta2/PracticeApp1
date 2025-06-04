using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Exceptions
{
    public class LikeNotFoundException : Exception
    {
        public LikeNotFoundException() { }

        public LikeNotFoundException(string message)
            : base(message)
        { }

        public LikeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
