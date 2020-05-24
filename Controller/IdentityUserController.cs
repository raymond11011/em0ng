using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.DatabaseContext;
using UserManagement.Entity;

namespace UserManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityUserController : ControllerBase
    {
        private readonly UserManageDBContext _context;

        public IdentityUserController(UserManageDBContext context)
        {
            _context = context;
        }

        // GET: api/IdentityUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetIdentityUser()
        {
            return await _context.IdentityUser.ToListAsync();
        }

        // GET: api/IdentityUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityUser>> GetIdentityUser(Guid id)
        {
            var identityUser = await _context.IdentityUser.FindAsync(id);

            if (identityUser == null)
            {
                return NotFound();
            }

            return identityUser;
        }

        // PUT: api/IdentityUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityUser(Guid id, IdentityUser identityUser)
        {
            if (id != identityUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(identityUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IdentityUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IdentityUser>> PostIdentityUser(IdentityUser identityUser)
        {
            _context.IdentityUser.Add(identityUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentityUser", new { id = identityUser.UserId }, identityUser);
        }

        // DELETE: api/IdentityUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentityUser>> DeleteIdentityUser(Guid id)
        {
            var identityUser = await _context.IdentityUser.FindAsync(id);
            if (identityUser == null)
            {
                return NotFound();
            }

            _context.IdentityUser.Remove(identityUser);
            await _context.SaveChangesAsync();

            return identityUser;
        }

        private bool IdentityUserExists(Guid id)
        {
            return _context.IdentityUser.Any(e => e.UserId == id);
        }
    }
}
