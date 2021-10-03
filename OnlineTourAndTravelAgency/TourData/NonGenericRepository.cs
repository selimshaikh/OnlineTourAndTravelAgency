using OnlineTourAndTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.TourData
{
    public class NonGenericRepository : INonGenericRepository
    {
        private readonly TourAndTravelDbContext _context;

        public NonGenericRepository(TourAndTravelDbContext context)
        {
            _context = context;
        }
        public async Task AddBooking(Booking booking)
        {
            int capacity = _context.Packages.Find(booking.PackageId).Capacity;
            int p = booking.NumberOfAdult;
            int q = booking.NumberOfChild;
            int z = p + q;
            int k = BookingCount(booking.PackageId) + z;
            if (capacity >= k)
            {
                booking.BookingDate = DateTime.Now;
                decimal adultPrice = decimal.Parse(_context.Packages.Where(x => x.PackageId == booking.PackageId).Select(y => y.PricePerAdult).ToString());
                decimal childPrice = decimal.Parse(_context.Packages.Where(x => x.PackageId == booking.PackageId).Select(y => y.PricePerChild).ToString());
                decimal totalPrice = adultPrice * booking.NumberOfAdult + childPrice * booking.NumberOfChild;
                booking.TotalPackagePrice = totalPrice;
                booking.IsCancellation = false;
                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();
            }
            else
            {

            }


        }

        public int BookingCount(int packageId)
        {
            return _context.Bookings.Where(x => x.PackageId == packageId).Count();

        }
        
        public int? GetLatestPackage()
        {
            var pak = _context.Packages.ToList();
            List<Packages> packages = new List<Packages>();
            foreach (var item in pak)
            {
                if (BookingCount(item.PackageId)<item.Capacity)
                {
                    packages.Add(item);
                }
            }
            var p= packages.OrderBy(x => x.StartDate).ThenByDescending(x => x.PackageId).FirstOrDefault();
            if (p==null)
            {
                return null;
            }
            else
            {
                int id = p.PackageId;
                return id;
            }

        }

    }
}