using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSAAS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using AutoSAAS.Models;

namespace AutoSAAS.Controllers
{
    // [Authorize]
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
        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValueById(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(i => i.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost("")]
        public void Poststring(string value) { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value) { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id) { }
    }
}