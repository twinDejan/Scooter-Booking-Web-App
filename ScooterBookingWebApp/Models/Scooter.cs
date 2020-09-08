using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScooterBookingWebApp.Models
{
    public class Scooter
    {
        public int Id { get; set; }

        [Display(Name = "Scooter Type")]
        public Type ScooterType { get; set; }
        
        [Required(ErrorMessage ="Please choose type")]
        public byte? TypeId { get; set; }

        [Required(ErrorMessage = "Please write description")]
        public string Description { get; set; }

        public string Speed { get; set; }

        public string Range { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please write location")]
        public string RideLocation { get; set; }

        [Display(Name = "Price")]
        public string PricePerHour { get; set; }

        [Display(Name = "Available")]
        public int Availability { get; set; }
        
    }
}