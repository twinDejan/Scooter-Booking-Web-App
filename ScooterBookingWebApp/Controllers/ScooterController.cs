using ScooterBookingWebApp.Models;
using ScooterBookingWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScooterBookingWebApp.Controllers
{
    public class ScooterController : Controller
    {

        ScooterDbContext _context = new ScooterDbContext { };
        
        public ScooterController()
        {
            _context = new ScooterDbContext();
        }

        // GET: Scooter
        [Authorize(Roles = "Administrator")]
        public ViewResult Index()
        {
            var allScooters = _context.Scooters.ToList();
            return View(allScooters);
        }
        // GET: Scooter 
        [Authorize(Roles = "Customer")]
        public ViewResult ScooterTable()
        {
            var allScooters = _context.Scooters.ToList();
            return View(allScooters);
        }

        [Authorize(Roles = "Administrator")]
        public ViewResult New()
        {
            var scooters = _context.Types.ToList();
            var selectedListItem = new List<SelectListItem> { };
            foreach (var item in scooters)
            {
                selectedListItem.Add(new SelectListItem { Text = item.TypeName, Value = item.Id.ToString() });
            }
            var viewModel = new ScooterFormViewModel
            {
                Scooter = new Scooter(),
                ScooterTypesSelected = selectedListItem
            };

            return View("ScooterForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Scooter scooter)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Incorrect Input";
                return RedirectToAction("ScooterForm");
            }

            _context.Scooters.Add(scooter);
            _context.SaveChanges();

            return RedirectToAction("Index", "Scooter");
        }

        public ActionResult Edit(int id)
        {
            var scooter = _context.Scooters.SingleOrDefault(a => a.Id == id);
            return View(scooter);
        }

        [HttpPost]
        public ActionResult Edit(Scooter scooter)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(scooter).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("BookedListAdmin");
            }
            return View(scooter);
        }

        public ActionResult Delete(int id)
        {
            var scooter = _context.Scooters.SingleOrDefault(t => t.Id == id);
            _context.Scooters.Remove(scooter);
            _context.SaveChanges();

            return RedirectToAction("Index", "Scooter");
        }

        [Authorize(Roles = "Customer")]
        public ActionResult BookScooter(int id)
        {
            if (_context.BookedScooters.Where(a => a.Id == id).Any())
            {
                var bookScooter = _context.BookedScooters.SingleOrDefault(a => a.Id == id);
                return View("ScooterAlreadyBooked", bookScooter);
            }
            var booked = new BookedScooter { };
            booked.Id = id;
            return View(booked);
        }


        [HttpPost]
        public ActionResult BookScooter(BookedScooter scooter)
        {
            if (ModelState.IsValid)
            {
                _context.BookedScooters.Add(scooter);
                _context.SaveChanges();
                return RedirectToAction("BookedList", "Scooter");
            }
            else
            return RedirectToAction("ScooterTable", "Scooter");
        }

        public ViewResult BookedList()
        {
            var allBookedScooters = _context.BookedScooters.ToList();
            return View(allBookedScooters);
        }

        public ActionResult Return(int id)
        {
            var scooter = _context.BookedScooters.SingleOrDefault(t => t.Id == id);
            _context.BookedScooters.Remove(scooter);
            _context.SaveChanges();

            return RedirectToAction("BookedList", "Scooter");
        }

        [Authorize(Roles = "Administrator")]
        public ViewResult BookedListAdmin()
        {
            var allBookedScooters = _context.BookedScooters.ToList();
            return View(allBookedScooters);
        }
    }
}