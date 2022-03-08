using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Exceptions
{
    public class NotAllowSpecialCharaterException : Exception
    {
        public NotAllowSpecialCharaterException(string message) : base(message)
        {
        }       
    }

    public class RegisterException : Exception
    {
        public RegisterException(string message) : base(message)
        {
        }
    }
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
