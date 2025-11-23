using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace securityJWT
{
   
   public interface ITokenService
{
    string GenerateToken(string username, string role);
}
}