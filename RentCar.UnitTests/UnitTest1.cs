using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentCar.Domain.Abstract;
using RentCar.Domain.Entities;
using RentCar.WebUI.Controllers;
using RentCar.WebUI.HtmlHelpers;
using RentCar.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RentCar.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Pagination()
        {
            IBrandRepository _brand;
            Mock<IBrandRepository> mockbrand = new Mock<IBrandRepository>();
            mockbrand.Setup(b => b.AllBrand).Returns(new List<Brand>
            {
                new Brand {NameBrand="BMW", NameModel="525"},
                new Brand {NameBrand="Merc", NameModel="Linkoln"},
                new Brand {NameBrand="Porshe", NameModel="911"}
            });
            _brand = mockbrand.Object;
            Mock<ICarRepository> mock = new Mock<ICarRepository>();
            mock.Setup(m => m.Cars).Returns(new List<Car>
            {
                new Car {NumberCar="AT3564AT", Brand = _brand.AllBrand.First()},
                new Car {NumberCar="BT3564BT", Brand = _brand.AllBrand.ElementAt(1)},
                new Car {NumberCar="BB5536AT", Brand = _brand.AllBrand.First()},
                new Car {NumberCar="AX3643BT", Brand = _brand.AllBrand.Last()},
                new Car {NumberCar="AA7534AX", Brand = _brand.AllBrand.First()}
            });
            CarController controller = new CarController(mock.Object);
            controller.pageSize = 3;

            CarsListViewModel result = (CarsListViewModel)controller.List(2).Model;

            List<Car> cars = result.Cars.ToList();
            Assert.IsTrue(cars.Count == 2);
            Assert.AreEqual(cars[0].Brand.NameBrand, "BMW");
            Assert.AreEqual(cars[1].Brand.NameBrand, "Merc");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalCar = 28,
                CarPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            IBrandRepository _brand;
            Mock<IBrandRepository> mockbrand = new Mock<IBrandRepository>();
            mockbrand.Setup(b => b.AllBrand).Returns(new List<Brand>
            {
                new Brand {NameBrand="BMW", NameModel="525"},
                new Brand {NameBrand="Merc", NameModel="Linkoln"},
                new Brand {NameBrand="Porshe", NameModel="911"}
            });
            _brand = mockbrand.Object;
            Mock<ICarRepository> mock = new Mock<ICarRepository>();
            mock.Setup(m => m.Cars).Returns(new List<Car>
            {
                new Car {NumberCar="AT3564AT", Brand = _brand.AllBrand.First()},
                new Car {NumberCar="BT3564BT", Brand = _brand.AllBrand.ElementAt(1)},
                new Car {NumberCar="BB5536AT", Brand = _brand.AllBrand.First()},
                new Car {NumberCar="AX3643BT", Brand = _brand.AllBrand.Last()},
                new Car {NumberCar="AA7534AX", Brand = _brand.AllBrand.First()}
            });
            CarController controller = new CarController(mock.Object);
            controller.pageSize = 3;

            CarsListViewModel result = (CarsListViewModel)controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.CarPerPage, 3);
            Assert.AreEqual(pageInfo.TotalCar, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
