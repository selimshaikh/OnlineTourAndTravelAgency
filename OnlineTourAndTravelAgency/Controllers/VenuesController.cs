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
    public class VenuesController : ControllerBase
    {
        private readonly IRepository<Venue> _repo;

        public VenuesController(IRepository<Venue> repo)
        {
            _repo = repo;
        }

        // GET: api/Venues
        [HttpGet]
        public async Task<IEnumerable<Venue>> GetVenue()
        {
            return await _repo.GetT();
        }
        // GET: api/Venues/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVenue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var venue = await _repo.GetTById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // POST: api/Venues
        [HttpPost]
        public async Task<ActionResult> PostVenue([FromBody] Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(venue);
            var save = await _repo.SaveAsync(venue);
            return CreatedAtAction("GetVenue", new { id = venue.VenueId }, venue);
        }

        // PUT: api/Venues/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue([FromRoute] int id, [FromBody] Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != venue.VenueId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(venue);
                var save = await _repo.SaveAsync(venue);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueExists(id))
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


        // DELETE: api/Venues/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVenue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var venue = await _repo.GetTById(id);
            if (venue == null)
            {
                return NotFound();
            }
            _repo.Delete(venue);
            await _repo.SaveAsync(venue);
            return Ok(venue);
        }

        private bool VenueExists(int id)
        {
            var venue = _repo.GetTById(id);
            if (venue == null)
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