using ScooterBookingWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScooterBookingWebApp.ViewModels
{
    public class ScooterFormViewModel
    {
        public List<SelectListItem> ScooterTypesSelected { get; set; }
        public Scooter Scooter { get; set; }
        public IEnumerable<Models.Type> Types { get; set; }

        public int? Id { get; set; }

        [Display(Name = "Type")]
        [Required]
        public byte? TypeId { get; set; }

        public string Description { get; set; }

        [Display(Name = "Max Speed")]
        public string Speed { get; set; }

        public string Range { get; set; }

        public string RideLocation { get; set; }

        public string PricePerHour { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        public int? Availability { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Scooter" : "New Scooter";
            }
        }

        public ScooterFormViewModel()
        {
            Id = 0;
        }

        public ScooterFormViewModel(Scooter scooter)
        {
            Id = scooter.Id;
            Description = scooter.Description;
            Speed = scooter.Speed;
            RideLocation = scooter.RideLocation;
            PricePerHour = scooter.PricePerHour;
            Availability = scooter.Availability;
            TypeId = scooter.TypeId;
        }

    }
}