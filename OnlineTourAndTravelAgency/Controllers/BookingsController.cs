using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTourAndTravelAgency.Models;
using OnlineTourAndTravelAgency.Tourdata;
using OnlineTourAndTravelAgency.TourData;

namespace OnlineTourAndTravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly INonGenericRepository _repo;
        private readonly IRepository<Booking> _bookingRepo;
        private readonly IRepository<Customer> _customer;
        private readonly IRepository<Packages> _packages;

        public BookingsController(INonGenericRepository repo, IRepository<Booking> bookingRepo,IRepository<Customer> customer,IRepository<Packages>packages)
        {
            _repo = repo;
            _bookingRepo = bookingRepo;
            _customer = customer;
            _packages = packages;
        }
        //api/Bookings
        [HttpPost]
        public async Task<ActionResult> PostBooking(Booking booking)
        {
            await _repo.AddBooking(booking);
            return Ok(booking);
        }
        //api/Bookings
        [HttpGet]
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            //return await _bookingRepo.GetT();
            var bookings =await _bookingRepo.GetT();
            foreach (var booking in bookings)
            {
                booking.Packages = await _packages.GetTById(booking.PackageId);
                booking.Packages.Bookings = null;

                booking.Customer = await _customer.GetTById(booking.CustomerId);
                booking.Customer.Bookings = null;
            }
            return bookings;
        }
        //Get: api/Bookings/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBooking([FromRoute] int id)
        {
            
            var booking = await _bookingRepo.GetTById(id);
            if (booking == null)
            {
                return NotFound();
            }
            booking.Customer = await _customer.GetTById(booking.CustomerId);
            booking.Customer.Bookings = null;
            booking.Packages = await _packages.GetTById(booking.PackageId);
            booking.Packages.Bookings = null;
            return Ok(booking);
        }
        //PUT:api/Bookings/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != booking.BookingId)
            {
                return BadRequest();
            }
            try
            {
                _bookingRepo.Update(booking);
                var save = await _bookingRepo.SaveAsync(booking);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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
        //DELETE:api/Bookings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var booking = await _bookingRepo.GetTById(id);
            if (booking==null)
            {
                return NotFound();
            }
            _bookingRepo.Delete(booking);
            await _bookingRepo.SaveAsync(booking);
            return Ok(booking);
        }
        private bool BookingExists(int id)
        {
            var hotel = _bookingRepo.GetTById(id);
            if (hotel==null)
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