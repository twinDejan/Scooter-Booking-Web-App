using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScooterBookingWebApp.Models
{
    public class BookedScooter
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Scooter Scooter { get; set; }

        [Display(Name = "Collecting Place")]
        [Required(ErrorMessage = "Please write collecting place")]
        public string CollectionPlace { get; set; }

        [Display(Name = "Returning Place")]
        [Required(ErrorMessage = "Please write returning place")]
        public string ReturnPlace { get; set; }

        private DateTime? dateCreated;
        [Display(Name = "Time Rented")]
        public DateTime TimeRented
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }

        [Display(Name = "Time to be Returned")]
        [Required(ErrorMessage = "Please write time to be returned")]
        public DateTime? TimeReturned { get; set; }

    }
}