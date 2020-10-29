using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {

            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
     /* Imagine you need to find an entity using your database context filtering by primary key.
There are two main options:
a) .FirstOrDefault()
b) .Find()

The latter one is the better one.
FirstOrDefault() method always executes a query on the database.
Find() method is more complicated. 
At first it checks if required entity is already loaded into in memory database context.
 If it is – the result is returned without hitting the database. 
 If not query on the database is executed 
 Notice that Find() method can operate only when primary key is passed as a parameter.*/
            var value = await _context.Values.FirstOrDefaultAsync(x=> x.Id==id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
