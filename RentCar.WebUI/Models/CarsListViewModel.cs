using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.WebUI.Models
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        public SelectList Categorys { get; set; }
        //public SelectList Brands { get; set; }
        public SelectList Transmissions { get; set; }
        public SelectList TypeBodys { get; set; }
        public SelectList Fuels { get; set; }
    }
}