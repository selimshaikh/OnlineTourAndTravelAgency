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
    public class NotesController : ControllerBase
    {
        private readonly IRepository<Notes> _repo;

        public NotesController(IRepository<Notes> repo)
        {
            _repo = repo;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<IEnumerable<Notes>> GetHotels()
        {
            return await _repo.GetT();
        }
        // GET: api/Notes/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var note = await _repo.GetTById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult> PostHotel([FromBody] Notes note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(note);
            var save = await _repo.SaveAsync(note);
            return CreatedAtAction("GetHotel", new { id = note.Noteid }, note);
        }

        // PUT: api/Notes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote([FromRoute] int id, [FromBody] Notes note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != note.Noteid)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(note);
                var save = await _repo.SaveAsync(note);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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


        // DELETE: api/Notes/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var note = await _repo.GetTById(id);
            if (note == null)
            {
                return NotFound();
            }
            _repo.Delete(note);
            await _repo.SaveAsync(note);
            return Ok(note);
        }


        private bool NoteExists(int id)
        {
            var note = _repo.GetTById(id);
            if (note == null)
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