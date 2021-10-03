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
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> _repo;

        public CustomersController(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetClient()
        {
            return await _repo.GetT();
        }
        // GET: api/Customer/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = await _repo.GetTById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult> PostClient([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(customer);
            var save = await _repo.SaveAsync(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // PUT: api/Customers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(customer);
                var save = await _repo.SaveAsync(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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


        // DELETE: api/Customers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = await _repo.GetTById(id);
            if (customer == null)
            {
                return NotFound();
            }
            _repo.Delete(customer);
            await _repo.SaveAsync(customer);
            return Ok(customer);
        }


        private bool CustomerExists(int id)
        {
            var customer = _repo.GetTById(id);
            if (customer == null)
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