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
            const int Port = 2231;
            const string ServerName = "ssd1.sscc.ru";
            const string Charset = "utf-8";

            var ssh = new Chilkat.Ssh();

            bool success = UnlockSSH(ssh);
            if(success != true)
            {
                return ssh.LastErrorText + "\nUnlock SSH failed";
            }

            success = ssh.Connect(ServerName, Port);
            if (success != true)
            {
                return ssh.LastErrorText + "\nConnection failed";
            }

            success = ssh.AuthenticatePw(user.Name, user.Password);
            if(success != true)
            {
                Console.WriteLine(ssh.LastErrorText + "\nUnlock SSH failed");
                return ssh.LastErrorText + "\nAuthenticate failed";
            }

            string strOutput = ssh.QuickCommand("ls", Charset);
            if (ssh.LastMethodSuccess != true)
            {
                Console.WriteLine(ssh.LastErrorText);
                return ssh.LastErrorText + "\nCommand failed";
            }
            Console.WriteLine(ssh.LastErrorText);

            return strOutput;
        }

        private bool UnlockSSH(Chilkat.Ssh ssh)
        {
            bool success = ssh.UnlockComponent("Unlockcode");
            if (success != true)
            {
                Console.WriteLine(ssh.LastErrorText + "\nUnlock failed");
                return success;
            }
            Console.WriteLine(ssh.LastErrorText + "\nUnlock succesful");
            return success;
        }
    }
}
