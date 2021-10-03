using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string HotelDetails { get; set; }
        public virtual ICollection<Packages> Packages { get; set; }
    }
}
