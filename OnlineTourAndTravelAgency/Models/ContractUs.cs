using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public class ContractUs
    {
        
            [Key]
            public int ContractId { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            public string Message { get; set; }
        
    }
}
