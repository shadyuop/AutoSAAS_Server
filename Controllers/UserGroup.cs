using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSAAS.Data;
using AutoSAAS.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AutoSAAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly DataContext _context;
        public UserGroupController(DataContext context)
        {
            _context = context;

        }

        // GET api/userGroup
        [HttpGet("")]
        public async Task<IActionResult> GetUserGroups()
        {
            var userGroups = await _context.UserGroups.ToListAsync();
            return Ok(userGroups);
        }

        // GET api/userGroup/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGroupById(int id)
        {
            var userGroup = await _context.UserGroups.SingleOrDefaultAsync( i => i.Id == id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return Ok(userGroup);
        }

        // POST api/userGroup
        [HttpPost("")]
        public async Task<IActionResult> PostUserGroup(UserGroup userGroup)
        {
            _context.UserGroups.Add(userGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroups", new { id = userGroup.Id }, userGroup);
        }

        // PUT api/userGroup/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup(int id, UserGroup userGroup)
        {
            userGroup.Id = id;
            _context.Entry(userGroup).State = EntityState.Modified;

           try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserGroups", new { id = userGroup.Id }, userGroup);
        }

        // DELETE api/userGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroupById(int id)
        {
            var userGroup = await _context.UserGroups.SingleOrDefaultAsync( i => i.Id == id);
            if (userGroup == null)
            {
                return NotFound();
            }

            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync();

            return Ok(userGroup);

        }

        private bool UserGroupExists(int id)
        {
            return _context.UserGroups.Any(e => e.Id == id);
        }
    }
}