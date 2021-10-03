using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public enum LocalTransportForsightseeing
    {
        car=1,
        jeep,
        Bus
    }
    public class Complementary
    {
        public int ComplementaryId { get; set; }
        [Required, EnumDataType(typeof(TransportType))]
       [ Display(Name = "Local Transport for sightseeing")]
        public LocalTransportForsightseeing LocalTransportForsightseeing { get; set; }
        [Required,Display(Name ="Meal Details")]
        public String MealDetails { get; set; }
        [Required, Display(Name = "Other Facilities")]
        public string OtherFacility { get; set; }
        public virtual ICollection<Packages> Packages { get; set; }

    }
}
