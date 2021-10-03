using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public enum TransportType
    {
        Bus=1,
        Train,
        Airline
    }
    public class Transport
    {
        public int TransportId { get; set; }
        [Required, EnumDataType(typeof(TransportType))]
        public TransportType TransportType { get; set; }
        public virtual ICollection<Packages> Packages { get; set; }
    }
}
