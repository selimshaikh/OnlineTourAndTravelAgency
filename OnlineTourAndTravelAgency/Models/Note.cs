using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineTourAndTravelAgency.Models
{
    public class Notes
    {
        [Key]
        public int Noteid { get; set; }
        [ForeignKey("Transport")]
        public int PackagesId { get; set; } 
        public string NoteDetails { get; set;}
        public virtual Packages Packages { get; set; }
    }
}
