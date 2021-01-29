    using RentCar.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCar.Domain.Entities;
using RentCar.Domain.Concrete;
using RentCar.WebUI.Models;
using System.Data.Entity;
using System.Net;

namespace RentCar.WebUI.Controllers
{
    public class CarController : Controller
    {
        //private ICarRepository repository;
        //public int pageSize = 4;
        //public CarController(ICarRepository repo)
        //{
        //    repository = repo;
        //}

        EFDbContext context = new EFDbContext();

        public ViewResult List(/*int page=1*/ int? category, int? transmission, int? fuel, int? typebody)
        {
            IQueryable<Car> cars = context.Cars.Include(p => p.Category);
            if (category != null && category != 0)
            {
                cars = cars.Where(p => p.Category.CategoryId == category);
            }
            List<Category> categories = context.Categories.ToList();
            categories.Insert(0, new Category { NameCategory = "Все", CategoryId = 0 });

            if (transmission != null && transmission != 0)
            {
                cars = cars.Where(v => v.Transmission.TransmissionId == transmission);
            }
            List<Transmission> transmissions = context.Transmissions.ToList();
            transmissions.Insert(0, new Transmission { NameTransmission = "Все", TransmissionId = 0 });

            if (fuel != null && fuel != 0)
            {
                cars = cars.Where(f => f.Fuel.FuelId == fuel);
            }
            List<Fuel> fuels = context.Fuels.ToList();
            fuels.Insert(0, new Fuel { NameFuel = "Все", FuelId = 0 });

            if (typebody != null && typebody != 0)
            {
                cars = cars.Where(t => t.TypeBody.BodyId == typebody);
            }
            List<TypeBody> typeBodies = context.TypeBodies.ToList();
            typeBodies.Insert(0, new TypeBody { NameBody = "Все", BodyId = 0 });

            CarsListViewModel viewModel = new CarsListViewModel
            {
                Cars = cars.ToList(),
                Categorys = new SelectList(categories, "CategoryId", "NameCategory"),
                Transmissions = new SelectList(transmissions, "TransmissionId", "NameTransmission"),
                TypeBodys = new SelectList(typeBodies, "BodyId", "NameBody"),
                Fuels = new SelectList(fuels, "FuelId", "NameFuel")
            };
            //CarsListViewModel model = new CarsListViewModel
            //{
            //    Cars = repository.Cars
            //    .OrderBy(car => car.NumberCar)
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize),
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage=page,
            //        CarPerPage=pageSize,
            //        TotalCar=repository.Cars.Count()
            //    }
            //};
            return View(viewModel);
        }

        //public ViewResult List()
        //{
        //     return View(context.Cars.ToList());
        //}
        //[HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> CarDescAsync(string carid)
        {
            if (carid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await context.Cars.FindAsync(carid);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
    }
}