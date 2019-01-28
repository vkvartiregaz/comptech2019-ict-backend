using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Контроллер Login

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "Hello world!";
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Hello world!";
        }
    }
}
