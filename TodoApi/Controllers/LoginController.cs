using Microsoft.AspNetCore.Mvc;
using System;

namespace comptech2019_ict.Controllers
{
    
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        // GET: api/Login/Logout
        [HttpGet("[action]")]
        public string Logout()
        {
            return "logout";
        }

        // POST: api/Login/Auth json body

        [HttpPost("[action]")]
        public string Auth([FromBody] User user)
        {
            return "Hello";
        }
    }
}
