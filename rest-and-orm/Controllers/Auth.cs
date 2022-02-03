using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_and_orm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_and_orm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] OurContext context, [FromBody] LoginRequest loginRequest)
        {
            TokenManager tokenManager = new TokenManager(context);
            var token = tokenManager.MakeToken(loginRequest.Username);
            return token is null ? Unauthorized() : Ok(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
    }
}
