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
    public class TransportsController : ControllerBase
    {
        private readonly IRepository<Transport> _repo;

        public TransportsController(IRepository<Transport> repo)
        {
            _repo = repo;
        }

        // GET: api/Transports
        [HttpGet]
        public async Task<IEnumerable<Transport>> GetTransport()
        {
            return await _repo.GetT();
        }
        // GET: api/Transports/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transport = await _repo.GetTById(id);
            if (transport == null)
            {
                return NotFound();
            }
            return Ok(transport);
        }

        // POST: api/Transports
        [HttpPost]
        public async Task<ActionResult> PostContract([FromBody] Transport transport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(transport);
            var save = await _repo.SaveAsync(transport);
            return CreatedAtAction("GetBuses", new { id = transport.TransportId }, transport);
        }

        // PUT: api/Transports/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransport([FromRoute] int id, [FromBody] Transport transport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != transport.TransportId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(transport);
                var save = await _repo.SaveAsync(transport);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(id))
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


        // DELETE: api/Transports/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transport = await _repo.GetTById(id);
            if (transport == null)
            {
                return NotFound();
            }
            _repo.Delete(transport);
            await _repo.SaveAsync(transport);
            return Ok(transport);
        }


        private bool TransportExists(int id)
        {
            var transport = _repo.GetTById(id);
            if (transport == null)
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