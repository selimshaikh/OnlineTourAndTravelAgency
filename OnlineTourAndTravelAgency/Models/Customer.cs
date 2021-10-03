using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public enum Gender
    {
        male = 1,
        Female,
        other
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Required, StringLength(80), Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [Required, StringLength(20), Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required, StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }
        [Required, StringLength(50), Display(Name = "NID")]
        public string NID { get; set; }
        [StringLength(50), Display(Name = "Passport Number")]
        public string Passport { get; set; }
        [Required, Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}