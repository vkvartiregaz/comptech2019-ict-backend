using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Контроллер Login

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly TodoContext _context;

        public LoginController(TodoContext context)
        {
            _context = context;

            if (_context.Credentials.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Credentials.Add(new Credentials { Username = "User" });
                _context.SaveChanges();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Credentials>> Post(Credentials item)
        {
            _context.Credentials.Add(item);
            await _context.SaveChangesAsync();
            
            return Ok(item);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var todoItem = await _context.Credentials.FindAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Credentials.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
