using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{


    public class CorporateTourPackage
    {
        public int ID { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Name of your organizations")]
        public string NameOfOrganization { get; set; }
        [Required]
        [Display(Name = "Type of business")]
        public string TypeOfBusiness { get; set; }
        [Required]
        [Display(Name = "Destination(s) Name")]
        public string DestinationName { get; set; }
        [Required]
        [Display(Name = "Number of guests (mention age if children)")]
        public string NumberOfGuests { get; set; }
        [Required]
        [Display(Name = "Duration of trip")]
        public string Durationoftrip { get; set; }
        [Required]
        [Display(Name = "Date of your journey")]
        public DateTime DateOfYourJourney { get; set; }
        [Required]
        [Display(Name = "Estimated budget")]
        [Column(TypeName = "money")]
        public decimal EstimatedBudget { get; set; }
        [Required]
        [Display(Name = "Contact person Name & Designation")]
        public string ContractPersonName { get; set; }
        [Required]
        [Display(Name = "Contact person Mobile")]
        public string ContactPersonMobile { get; set; }
        [Required]
        [Display(Name = "Office address ")]
        public string OfficeAddress { get; set; }
        public string Note { get; set; }
    }
}


