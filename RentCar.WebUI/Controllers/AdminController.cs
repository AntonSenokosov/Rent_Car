using RentCar.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //ICarRepository repository;

        //public AdminController(ICarRepository repo)
        //{
        //    repository = repo;
        //}
        // GET: Admin
        public ViewResult Index()
        {
            return View();
        }
    }
}