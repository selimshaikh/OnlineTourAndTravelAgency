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
    public class HotelsController : ControllerBase
    {
        private readonly IRepository<Hotel> _repo;

        public HotelsController(IRepository<Hotel> repo)
        {
            _repo = repo;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _repo.GetT();
        }
        // GET: api/Hotels/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = await _repo.GetTById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult> PostHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(hotel);
            var save = await _repo.SaveAsync(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }

        // PUT: api/Hotels/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(hotel);
                var save = await _repo.SaveAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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


        // DELETE: api/Hotels/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = await _repo.GetTById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            _repo.Delete(hotel);
            await _repo.SaveAsync(hotel);
            return Ok(hotel);
        }


        private bool HotelExists(int id)
        {
            var hotel = _repo.GetTById(id);
            if (hotel == null)
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