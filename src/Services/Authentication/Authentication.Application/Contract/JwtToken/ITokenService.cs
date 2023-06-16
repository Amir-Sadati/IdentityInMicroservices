using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Contract.JwtToken
{
    public interface ITokenService
    {
       Task<string> CreateToken(IdentityUser user);
       string ValidateToken(string token);
    }
}
