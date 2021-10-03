using OnlineTourAndTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.TourData
{
    public interface INonGenericRepository
    {
        Task AddBooking(Booking booking);
        int BookingCount(int packageId);
        int? GetLatestPackage();

    }

}
