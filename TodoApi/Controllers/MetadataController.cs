using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class MetadataController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "Hello world from Get()";
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Hello world from Get(id)";
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string value)
        {
            return "Hello world from Put";
        }
    }
}
