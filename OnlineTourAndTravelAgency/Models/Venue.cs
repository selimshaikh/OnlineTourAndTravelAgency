using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{  
        public class Venue
        {
            public int VenueId { get; set; }
            public string Name { get; set; }
            public String  VenueDetails { get; set; }
            public string SpotImage { get; set; }
            public virtual ICollection<Packages> Packages { get; set; }
        }
    
}
