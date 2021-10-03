using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTourAndTravelAgency.Models;
using OnlineTourAndTravelAgency.Tourdata;

namespace OnlineTourAndTravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidesController : ControllerBase
    {
        private readonly IRepository<Guide> _repo;

        public GuidesController(IRepository<Guide> repo)
        {
            _repo = repo;
        }

        // GET: api/Guides
        [HttpGet]
        public async Task<IEnumerable<Guide>> GetCenters()
        {
            return await _repo.GetT();
        }
        // GET: api/Guides/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGuide([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var guide = await _repo.GetTById(id);
            if (guide == null)
            {
                return NotFound();
            }
            return Ok(guide);
        }

        // POST: api/Guides
        [HttpPost]
        public async Task<ActionResult> PostGuide([FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(guide);
            var save = await _repo.SaveAsync(guide);
            return CreatedAtAction("GetGuide", new { id = guide.GuideId }, guide);
        }

        // PUT: api/Guides/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuide([FromRoute] int id, [FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != guide.GuideId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(guide);
                var save = await _repo.SaveAsync(guide);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(id))
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


        // DELETE: api/Guides/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuide([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var guide = await _repo.GetTById(id);
            if (guide == null)
            {
                return NotFound();
            }
            _repo.Delete(guide);
            await _repo.SaveAsync(guide);
            return Ok(guide);
        }


        private bool GuideExists(int id)
        {
            var guide = _repo.GetTById(id);
            if (guide == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
