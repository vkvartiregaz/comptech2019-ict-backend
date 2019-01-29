using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Контроллер Collection

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : Controller
    {
        private readonly TodoContext _context;

        public CollectionController(TodoContext context)
        {
            _context = context;

            if (_context.CollectionContents.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.CollectionContents.Add(new CollectionContents { Name = "name" });
                _context.SaveChanges();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{path}")]
        public async Task<ActionResult<CollectionContents>> Get(string path)
        {
            var todoItem = await _context.CollectionContents.FindAsync(path);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<CollectionContents>> Post(CollectionContents item)
        {
            _context.CollectionContents.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // PUT api/<controller>/5
        [HttpPut("{path}")]
        public async Task<IActionResult> Put(string path, string newPath)
        {
            if (path != newPath) {
                return BadRequest();
            }
            var todoItem = await _context.CollectionContents.FindAsync(newPath);
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var todoItem = await _context.CollectionContents.FindAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.CollectionContents.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
