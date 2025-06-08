using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException() { }

        public PostNotFoundException(string message)
            : base(message)
        { }

        public PostNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
