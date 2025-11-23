using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace securityJWT
{
    public class LoginModel
    {
        public record LoginModell(string Username, string Password);

    }
}