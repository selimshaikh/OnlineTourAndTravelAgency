using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
        public class Tour
        {
            public int TourId { get; set; }
            [Required, StringLength(50), Display(Name = "Tour Title")]
            public string TourTitle { get; set; }
            public int NumberOfPackage { get; set; }
            public virtual ICollection<Packages> Packages { get; set; }
        }
    
}
