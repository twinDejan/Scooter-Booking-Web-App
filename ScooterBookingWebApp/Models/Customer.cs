using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScooterBookingWebApp.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please write your name")]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type ID")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please write date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }


    }
}