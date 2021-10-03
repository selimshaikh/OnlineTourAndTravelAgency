using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required,Display(Name ="Number or Adult")]
        public int NumberOfAdult { get; set; }
        [Display(Name = "Number or Child")]
        public int NumberOfChild { get; set; }
        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Total price for the Package")]
        public decimal TotalPackagePrice { get; set; }
        [Required]
        public bool IsCancellation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Packages Packages { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }

    }
}
