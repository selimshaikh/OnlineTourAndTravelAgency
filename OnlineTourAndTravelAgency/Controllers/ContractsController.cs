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
    public class ContractController : ControllerBase
    {
        private readonly IRepository<ContractUs> _repo;

        public ContractController(IRepository<ContractUs> repo)
        {
            _repo = repo;
        }

        // GET: api/contract
        [HttpGet]
        public async Task<IEnumerable<ContractUs>> GetCenters()
        {
            return await _repo.GetT();
        }
        // GET: api/contract/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contract = await _repo.GetTById(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        // POST: api/contract
        [HttpPost]
        public async Task<ActionResult> PostContract([FromBody] ContractUs contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(contract);
            var save = await _repo.SaveAsync(contract);
            return CreatedAtAction("GetCenter", new { id = contract.ContractId }, contract);
        }

        // PUT: api/contract/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractUs([FromRoute] int id, [FromBody] ContractUs contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != contract.ContractId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(contract);
                var save = await _repo.SaveAsync(contract);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
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


        // DELETE: api/contract/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContractUs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contract = await _repo.GetTById(id);
            if (contract == null)
            {
                return NotFound();
            }
            _repo.Delete(contract);
            await _repo.SaveAsync(contract);
            return Ok(contract);
        }


        private bool ContractExists(int id)
        {
            var contract = _repo.GetTById(id);
            if (contract == null)
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
