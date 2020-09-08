using ScooterBookingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScooterBookingWebApp.ViewModels
{
    public class BookViewModel
    {
        public Scooter Scooter { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}