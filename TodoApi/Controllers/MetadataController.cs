using Microsoft.AspNetCore.Mvc;

namespace comptech2019_ict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaDataController : ControllerBase
    {
        public class Metadata
        {
            public string Info { get; set; }
        }
        // GET: api/MetaData получить список метаданных
        [HttpGet]
        public string[] Get()
        {
            return new string[] { "123", "456", "789" };
        }

        // GET: api/MetaData/Name
        [HttpGet("{Name}", Name = "Get")]
        public Metadata Get(string Name)
        {
            return new Metadata { Info = "123" };
        }

        // PUT: api/MetaData/5
        [HttpPut("{Name}")]
        public void Put(string Name, [FromBody] string value)
        {
        }
    }
}
