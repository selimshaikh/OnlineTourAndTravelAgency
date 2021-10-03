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
    public class PackagesController : ControllerBase
    {
        private readonly IRepository<Packages> _repo;
        private readonly IRepository<Transport> _transport;
        private readonly IRepository<Complementary> _complementary;
        private readonly IRepository<Guide> _guide;
        private readonly IRepository<Hotel> _hotel;
        private readonly IRepository<Tour> _tour;
        private readonly IRepository<Venue> _venue;
        private readonly INonGenericRepository non;

        public PackagesController(IRepository<Packages> repo, IRepository<Transport> transport, IRepository<Complementary> complementary, IRepository<Guide> guide, IRepository<Hotel> hotel, IRepository<Tour> tour, IRepository<Venue> venue, INonGenericRepository non)
        {
            _repo = repo;
            _transport = transport;
            _complementary = complementary;
            _guide = guide;
           _hotel = hotel;
            _tour = tour;
            _venue = venue;
            this.non = non;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<IEnumerable<Packages>> GetPackages()
        {
            //return await _repo.GetT();
            var packages = await _repo.GetT();
            foreach (var package in packages)
            {
                package.Transport = await _transport.GetTById(package.TransportId);
                package.Transport.Packages = null;
                package.Guide = await _guide.GetTById(package.GuideId);
                package.Guide.Packages = null;
                package.Complementary = await _complementary.GetTById(package.ComplementaryId);
                package.Complementary.Packages = null;
                package.Hotel = await _hotel.GetTById(package.HotelId);
                package.Hotel.Packages = null;
                package.Venue = await _venue.GetTById(package.VenueId);
                package.Venue.Packages = null;
                package.Tour = await _tour.GetTById(package.TourId);
                package.Tour.Packages = null;

            }
            return packages;
        }
        // GET: api/Packages/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var package = await _repo.GetTById(id);
            if (package == null)
            {
                return NotFound();
            }
            package.Transport = await _transport.GetTById(package.TransportId);
            package.Transport.Packages = null;
            package.Guide = await _guide.GetTById(package.GuideId);
            package.Guide.Packages = null;
            package.Complementary = await _complementary.GetTById(package.ComplementaryId);
            package.Complementary.Packages = null;
            package.Hotel = await _hotel.GetTById(package.HotelId);
            package.Hotel.Packages = null;
            package.Venue = await _venue.GetTById(package.VenueId);
            package.Venue.Packages = null;
            package.Tour = await _tour.GetTById(package.TourId);
            package.Tour.Packages = null;
            return Ok(package);
        }

        // POST: api/Packages
        [HttpPost]
        public async Task<ActionResult> PostPackage([FromBody] Packages package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(package);
            await _repo.SaveAsync(package);
            return CreatedAtAction("GetPackage", new { id = package.PackageId }, package);
        }

        // PUT: api/Packages/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage([FromRoute] int id, [FromBody] Packages package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != package.PackageId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(package);
                var save = await _repo.SaveAsync(package);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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


        // DELETE: api/Packages/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var package = await _repo.GetTById(id);
            if (package == null)
            {
                return NotFound();
            }
            _repo.Delete(package);
            await _repo.SaveAsync(package);
            return Ok(package);
        }
        // GET: api/Packages
        [Route("/HotPackages")]
        [HttpGet]
        public async Task<ActionResult> GetLatestPackagesPackages()
        {
            //return await _repo.GetT();
            int? packageId = non.GetLatestPackage();
            if (packageId==null)
            {
                Packages p = new Packages();
                p.PackageName = "";
                p.EndDate = DateTime.Now;
                p.GuideId = 1;
                p.ComplementaryId = 1;
                p.StartDate = DateTime.Now;
                p.TourId = 1;
                p.TransportId = 1;
                p.VenueId = 1;
                p.PricePerChild = 0;
                p.PricePerAdult = 0;
                p.HotelId = 1;
                
                return Ok(p);
            }
            else
            {
                var package = await GetPackage((int)(packageId));
                return Ok(package);
            }
           

            
        }

        private bool PackageExists(int id)
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