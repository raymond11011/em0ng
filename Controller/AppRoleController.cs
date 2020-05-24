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
    public class AppRoleController : ControllerBase
    {
        private readonly UserManageDBContext _context;

        public AppRoleController(UserManageDBContext context)
        {
            _context = context;
        }

        // GET: api/AppRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppRole>>> GetAppRole()
        {
            return await _context.AppRole.ToListAsync();
        }

        // GET: api/AppRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppRole>> GetAppRole(Guid id)
        {
            var appRole = await _context.AppRole.FindAsync(id);

            if (appRole == null)
            {
                return NotFound();
            }

            return appRole;
        }

        // PUT: api/AppRole/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppRole(Guid id, AppRole appRole)
        {
            if (id != appRole.AppRoleId)
            {
                return BadRequest();
            }

            _context.Entry(appRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppRoleExists(id))
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

        // POST: api/AppRole
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AppRole>> PostAppRole(AppRole appRole)
        {
            _context.AppRole.Add(appRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppRole", new { id = appRole.AppRoleId }, appRole);
        }

        // DELETE: api/AppRole/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppRole>> DeleteAppRole(Guid id)
        {
            var appRole = await _context.AppRole.FindAsync(id);
            if (appRole == null)
            {
                return NotFound();
            }

            _context.AppRole.Remove(appRole);
            await _context.SaveChangesAsync();

            return appRole;
        }

        private bool AppRoleExists(Guid id)
        {
            return _context.AppRole.Any(e => e.AppRoleId == id);
        }
    }
}
