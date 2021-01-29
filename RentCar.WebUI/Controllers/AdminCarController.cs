using RentCar.Domain.Abstract;
using RentCar.Domain.Concrete;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        EFDbContext db = new EFDbContext();

        [HttpGet]
        public ActionResult CreateCar()
        {
            SelectList brand = new SelectList(db.Brands, "BrandId", "NameBrand");
            ViewBag.Brands = brand;
            SelectList category = new SelectList(db.Categories, "CategoryId", "NameCategory");
            ViewBag.Categories = category;
            SelectList transmission = new SelectList(db.Transmissions, "TransmissionId", "NameTransmission");
            ViewBag.Transmissions = transmission;
            SelectList fuels = new SelectList(db.Fuels, "FuelId", "NameFuel");
            ViewBag.Fuels = fuels;
            SelectList body = new SelectList(db.TypeBodies, "BodyId", "NameBody");
            ViewBag.TypeBodies = body;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCar(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("AdminCar");
        }

        public ViewResult AdminCar()
        {
            var car = db.Cars.Include(p => p.Brand);
            car = db.Cars.Include(v => v.Category);
            car = db.Cars.Include(v => v.Fuel);
            car = db.Cars.Include(v => v.TypeBody);
            car = db.Cars.Include(v => v.Transmission);
            return View(car.ToList());
        }
    }
}