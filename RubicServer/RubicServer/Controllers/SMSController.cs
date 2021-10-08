using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubicServer.Contexts;
using RubicServer.Models;

namespace RubicServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly UserContext _context;

        public SMSController(UserContext context)
        {
            _context = context;
        }

        // GET: api/SMS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SMS>>> GetSMS()
        {
            return await _context.SMS.ToListAsync();
        }

        // GET: api/SMS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SMS>> GetSMS(int id)
        {
            var sMS = await _context.SMS.FindAsync(id);

            if (sMS == null)
            {
                return NotFound();
            }

            return sMS;
        }

        // PUT: api/SMS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSMS(int id, SMS sMS)
        {
            if (id != sMS.Id)
            {
                return BadRequest();
            }

            _context.Entry(sMS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMSExists(id))
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

        // POST: api/SMS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SMS>> PostSMS(SMS sMS)
        {
            _context.SMS.Add(sMS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSMS", new { id = sMS.Id }, sMS);
        }

        // DELETE: api/SMS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SMS>> DeleteSMS(int id)
        {
            var sMS = await _context.SMS.FindAsync(id);
            if (sMS == null)
            {
                return NotFound();
            }

            _context.SMS.Remove(sMS);
            await _context.SaveChangesAsync();

            return sMS;
        }

        private bool SMSExists(int id)
        {
            return _context.SMS.Any(e => e.Id == id);
        }
    }
}
