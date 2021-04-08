using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wave_analysis_rebuild.Models;

namespace wave_analysis_rebuild.Controllers
{
    [Route("api/v2/sessions/")]
    [ApiController]
    public class MetaDatasController : ControllerBase
    {
        private readonly MetaDataContext _context;

        public MetaDatasController(MetaDataContext context)
        {
            _context = context;
        }

        // GET: api/MetaDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaData>>> GetMetaData()
        {
            return await _context.MetaData.ToListAsync();
        }

        // GET: api/MetaDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetaData>> GetMetaData(long id)
        {
            var metaData = await _context.MetaData.FindAsync(id);

            if (metaData == null)
            {
                return NotFound();
            }

            return metaData;
        }

        // PUT: api/MetaDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaData(long id, MetaData metaData)
        {
            if (id != metaData.id)
            {
                return BadRequest();
            }

            _context.Entry(metaData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaDataExists(id))
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

        // POST: api/MetaDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MetaData>> PostMetaData(MetaData metaData)
        {
            _context.MetaData.Add(metaData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetaData", new { id = metaData.id }, metaData);
        }

        // DELETE: api/MetaDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MetaData>> DeleteMetaData(long id)
        {
            var metaData = await _context.MetaData.FindAsync(id);
            if (metaData == null)
            {
                return NotFound();
            }

            _context.MetaData.Remove(metaData);
            await _context.SaveChangesAsync();

            return metaData;
        }

        private bool MetaDataExists(long id)
        {
            return _context.MetaData.Any(e => e.id == id);
        }
    }
}
