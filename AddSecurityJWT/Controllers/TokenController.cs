using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddSecurityJWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddSecurityJWT.Controllers;

[ApiController]
[Route("api/token")]
public class TokenController(JwtTokenProvider tokenProvider) : ControllerBase
{

    [HttpPost("generate")]
    public IActionResult GenerateToken(GenerateTokenRequest request)
    {
        return Ok(tokenProvider.GenerateJwtToken(request));
    }
}