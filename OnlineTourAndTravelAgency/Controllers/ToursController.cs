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
    public class ToursController : ControllerBase
    {
        private readonly IRepository<Tour> _repo;

        public ToursController(IRepository<Tour> repo)
        {
            _repo = repo;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<IEnumerable<Tour>> GetTour()
        {
            return await _repo.GetT();
        }
        // GET: api/Tours/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTour([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tour = await _repo.GetTById(id);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(tour);
        }

        // POST: api/Tours
        [HttpPost]
        public async Task<ActionResult> PostTour([FromBody] Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(tour);
            var save = await _repo.SaveAsync(tour);
            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        // PUT: api/Tours/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour([FromRoute] int id, [FromBody] Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != tour.TourId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(tour);
                var save = await _repo.SaveAsync(tour);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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


        // DELETE: api/Tours/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTour([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tour = await _repo.GetTById(id);
            if (tour == null)
            {
                return NotFound();
            }
            _repo.Delete(tour);
            await _repo.SaveAsync(tour);
            return Ok(tour);
        }


        private bool TourExists(int id)
        {
            var tour = _repo.GetTById(id);
            if (tour == null)
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