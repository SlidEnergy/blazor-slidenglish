using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlidEnglish.Domain;
using SlidEnglish.Server;

namespace SlidEnglish.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsageExamplesController : ControllerBase
    {
        private readonly SlidEnglishContext _context;

        public UsageExamplesController(SlidEnglishContext context)
        {
            _context = context;
        }

        // GET: api/UsageExamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsageExample>>> GetUsageExample()
        {
            return await _context.UsageExample.ToListAsync();
        }

        // GET: api/UsageExamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsageExample>> GetUsageExample(int id)
        {
            var usageExample = await _context.UsageExample.FindAsync(id);

            if (usageExample == null)
            {
                return NotFound();
            }

            return usageExample;
        }

        // PUT: api/UsageExamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsageExample(int id, UsageExample usageExample)
        {
            if (id != usageExample.Id)
            {
                return BadRequest();
            }

            _context.Entry(usageExample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsageExampleExists(id))
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

        // POST: api/UsageExamples
        [HttpPost]
        public async Task<ActionResult<UsageExample>> PostUsageExample(UsageExample usageExample)
        {
            _context.UsageExample.Add(usageExample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsageExample", new { id = usageExample.Id }, usageExample);
        }

        // DELETE: api/UsageExamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsageExample>> DeleteUsageExample(int id)
        {
            var usageExample = await _context.UsageExample.FindAsync(id);
            if (usageExample == null)
            {
                return NotFound();
            }

            _context.UsageExample.Remove(usageExample);
            await _context.SaveChangesAsync();

            return usageExample;
        }

        private bool UsageExampleExists(int id)
        {
            return _context.UsageExample.Any(e => e.Id == id);
        }
    }
}
