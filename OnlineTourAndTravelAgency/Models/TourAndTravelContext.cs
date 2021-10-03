using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class TourAndTravelDbContext : DbContext
    {
        public TourAndTravelDbContext(DbContextOptions<TourAndTravelDbContext> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Transport> Transports{ get; set; }
        public DbSet<Complementary> Complementaries { get; set; }
        public DbSet<CorporateTourPackage> CorporateTourPackages { get; set; }
        public DbSet<ContractUs> ContractUs { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Notes> Notess { get; set; }
    }
}