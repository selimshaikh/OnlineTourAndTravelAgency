using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class Packages
    {
        [Key]
        public int PackageId { get; set; }
        [Required, StringLength(80), Display(Name = "Package Name")]
        public string PackageName { get; set; }
        [Required, ForeignKey("Tour")]
        public int TourId { get; set; }
        [Required, ForeignKey("Guide")]
        public int GuideId { get; set; }
        [Required, ForeignKey("Venue")]
        public int VenueId { get; set; }
        [Required, ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [Required, ForeignKey("Transport")]
        public int TransportId { get; set; }
        [Required, ForeignKey("Complementary")]
        public int ComplementaryId { get; set; }
        [Required, Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Package Price Per Adult")]
        public decimal PricePerAdult { get; set; }
        [Required]
        [Display(Name = "Package Price Per Child")]
        public decimal PricePerChild { get; set; }
        public int Capacity { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual Guide Guide { get; set; }
        public virtual Transport Transport { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
        public virtual Complementary Complementary { get; set; }
    }
}
