using AutoMapper;
using ScooterBookingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using ScooterBookingWebApp.ViewModels;

namespace ScooterBookingWebApp.Controllers
{
    public class CustomerController : Controller
    {

        ScooterDbContext _context = new ScooterDbContext { };

        public CustomerController()
        {
            _context = new ScooterDbContext();
        }
        // GET: Customer
        public ViewResult Index()
        {
            // ovde zemi gi site customers od baza i vrati gi vo view index
            var allCustomers = _context.Customers.ToList();
            return View(allCustomers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var selectedListItem = new List<SelectListItem> { };
            // so e bitnoto kaj dropdownot - vo mvc!
            // mora da e od tipot selctedlist item i da ima text i value , a so lista ne faka.
            foreach(var item in membershipTypes)
            {
                selectedListItem.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
                 
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypesSelected = selectedListItem
            };

            return View("CustomerForm", viewModel);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Incorrect Input";
                return RedirectToAction("CustomerForm");
            }        
            _context.Customers.Add(customer);           
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }



        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(t => t.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}