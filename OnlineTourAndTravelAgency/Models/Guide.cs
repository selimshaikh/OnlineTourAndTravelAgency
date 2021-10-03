using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class Guide
    {
        public int GuideId { get; set; }
        [Required]
        [Display(Name = "Guide Name")]
        public string GuideName { get; set; }
        public string Skill { get; set;}
        public virtual ICollection<Packages> Packages { get; set; }


    }
}
