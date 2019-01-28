using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace comptech2019_ict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        public class Object
        {
            public string Name { get; set; }
            //public string Charset { get; set; }
            public byte[] Data { get; set; }
        }

        // GET: api/object список объектов
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Some object1", "Some object2" };
        }

        // GET: api/object/name получить объект по имени 
        [HttpGet("{Name}")]
        public Object Get(string Name)
        {
            return new Object
            {
                Name = "TestObject",
                Data = new byte[] { 1,2,3,4,5,6,7,9 }
            };
        }

        // POST: api/Object создать объект json строковое представление
        //[HttpPost("{Name}")]
        //public async Task<Object> Post(string Name)
        //{
        //    using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
        //    {
        //        return new Object
        //        {
        //            Name = Name,
        //            Data = await reader.ReadToEndAsync()
        //        };
        //    }
        //}

        [HttpPost("{Name}")]
        public async Task<Object> Post(string Name)
        {
            using (var ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
                return new Object
                {
                    Name = Name,
                    Data = ms.ToArray(),
                };
            }
        }

        //[HttpPost("{Name}")]
        //public async Task<string> Post(string Name)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        await Request.Body.CopyToAsync(ms);
        //        return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        //    }
        //}

        // PUT: api/Object/name переименовать объект по имени
        [HttpPut("{name}")]
        public void Put(string Name, [FromBody] string value)
        {
        }

        // DELETE: api/Object/name удалить объект по имени
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
        }
    }
}