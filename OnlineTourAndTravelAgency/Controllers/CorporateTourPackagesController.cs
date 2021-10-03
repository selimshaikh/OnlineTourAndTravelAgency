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
    public class CorporateTourPackagesController : ControllerBase
    {
        private readonly IRepository<CorporateTourPackage> _repo;
        public CorporateTourPackagesController(IRepository<CorporateTourPackage> repo)
        {
            _repo = repo;
        }
        // GET: api/CorporateTourPackages
        [HttpGet]
        public async Task<IEnumerable<CorporateTourPackage>> GetCenters()
        {
            return await _repo.GetT();
        }
        // GET: api/CorporateTourPackages/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var corporateTourPackage = await _repo.GetTById(id);
            if (corporateTourPackage == null)
            {
                return NotFound();
            }
            return Ok(corporateTourPackage);
        }
        // POST: api/CorporateTourPackages
        [HttpPost]
        public async Task<ActionResult> PostCorporateTourPackages([FromBody] CorporateTourPackage CorporateTourPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(CorporateTourPackage);
            var save = await _repo.SaveAsync(CorporateTourPackage);
            return CreatedAtAction("GetCenter", new { id = CorporateTourPackage.ID}, CorporateTourPackage);
        }
        // PUT: api/CorporateTourPackages/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorporateTourPackage([FromRoute] int id, [FromBody] CorporateTourPackage corporateTourPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != corporateTourPackage.ID)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(corporateTourPackage);
                var save = await _repo.SaveAsync(corporateTourPackage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!corporateTourPackageExists(id))
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
        // DELETE: api/CorporateTourPackages/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCorporateTourPackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var corporateTourPackage = await _repo.GetTById(id);
            if (corporateTourPackage == null)
            {
                return NotFound();
            }
            _repo.Delete(corporateTourPackage);
            await _repo.SaveAsync(corporateTourPackage);
            return Ok(corporateTourPackage);
        }


        private bool corporateTourPackageExists(int id)
        {
            var corporateTourPackage = _repo.GetTById(id);
            if (corporateTourPackage == null)
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