using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Exceptions
{
    /// <summary>
    /// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
    /// Date : 17 Apr 2023
    /// Description : Exception Handling
    /// </summary>
    class AuthenicationException : Exception
    {
        public class AuthenticationException : Exception
        {
            public AuthenticationException(string message) : base(message)
            {
            }
            public AuthenticationException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
