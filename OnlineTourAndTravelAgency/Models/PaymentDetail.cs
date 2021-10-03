using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTourAndTravelAgency.Models
{
    public enum paymentSystem
    {
        Cash=1,
        bKash,
        Check,
        other
    }
    public class PaymentDetail
    {
        public int ID { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Required, EnumDataType(typeof(paymentSystem))]
        public paymentSystem paymentSystem { get; set; }
        [Required,StringLength(11)]
        [Display(Name = "bKash number")]
        public string BKashNumber { get; set; }
        [StringLength(200)]
        [Display(Name = "Bank Details")]
        public string BankDetails { get; set; }
        [StringLength(200)]
        [Display(Name ="Other transaction details")]
        public string OtherDetails { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
