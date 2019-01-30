using Microsoft.AspNetCore.Mvc;
using System;
using TodoApi;

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
            return SshClient.Disconnect();
        }

        // POST: api/Login/Auth json body

        [HttpPost("[action]")]
        public string Auth([FromBody] User user)
        {
            SshClient.SetConnectionInfo("ssd1.sscc.ru", 2231, user.Name, user.Password);
            try
            {
                SshClient.Connect();
            }
            catch(Exception e)
            {
                return "Some errors in connection" + e.Message;
            }
            return "Connected to " + SshClient.ConnectionInfo.Host;
        }
    }
}
