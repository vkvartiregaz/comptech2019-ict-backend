using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace comptech2019_ict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        public class Collection
        {
            public string Name { get; set; }
            public string[] Objects { get; set; }
        }

        // GET: api/Collection список коллекций
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Some collection1" , "Some collection2" };
        }

        // GET: api/Collection/name получить коллекцию по имени 
        [HttpGet("{Name}")]
        public string Get(string Name)
        {
            return "Collection by name";
        }

        // POST: api/Collection создать коллекцию json
        [HttpPost]
        public void Post([FromBody] Collection value)
        {
        }

        // PUT: api/Collection/name переименовать коллекцию по имени
        [HttpPut("{name}")]
        public void Put(string Name, [FromBody] string value)
        {
        }

        // DELETE: api/Collection/name удалить коллекцию по имени
        [HttpDelete("{name}")]
        public void Delete(string name)
        {

        }
    }
}
