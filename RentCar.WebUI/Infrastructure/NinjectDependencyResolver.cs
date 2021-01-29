using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using RentCar.Domain.Abstract;
using RentCar.Domain.Concrete;
using RentCar.Domain.Entities;

namespace GameStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //IBrandRepository _brand;
            //ICategoryRepository _category;
            //ITransmissionRepository _transmission;
            //Mock<IBrandRepository> mockbrand = new Mock<IBrandRepository>();
            //mockbrand.Setup(b => b.AllBrand).Returns(new List<Brand>
            //{
            //    new Brand {NameBrand="BMW", NameModel="525"},
            //    new Brand {NameBrand="Merc", NameModel="Linkoln"},
            //    new Brand {NameBrand="Porshe", NameModel="911"}
            //});
            //_brand = mockbrand.Object;

            //Mock<ICategoryRepository> mockcategory = new Mock<ICategoryRepository>();
            //mockcategory.Setup(c => c.AllCategories).Returns(new List<Category>
            //{
            //    new Category {NameCategory="FFFF"},
            //    new Category {NameCategory="TTTT"}
            //});
            //_category = mockcategory.Object;
            //Mock<ITransmissionRepository> mocktransmission = new Mock<ITransmissionRepository>();
            //mocktransmission.Setup(t => t.AllTransmissions).Returns(new List<Transmission>
            //{
            //    new Transmission {NameTransmission="Auto"},
            //    new Transmission {NameTransmission="Rychnoi"}
            //});
            //_transmission = mocktransmission.Object;
            //Mock<ICarRepository> mock = new Mock<ICarRepository>();
            //mock.Setup(m => m.Cars).Returns(new List<Car>
            //{
            //    new Car {NumberCar="ВТ2363ВТ", Brand=_brand.AllBrand.First(), Category =_category.AllCategories.First(), Transmission= _transmission.AllTransmissions.First(), year=2001, typeBody="hhh", coutDoor=3, costOfDay=25, available=true, isFavorite=true},
            //    new Car {NumberCar="AТ4526ВТ", Brand=_brand.AllBrand.ElementAt(1), Category =_category.AllCategories.Last(), Transmission=_transmission.AllTransmissions.Last(), year=2013, typeBody="nnn", coutDoor=4, costOfDay=45, available=true, isFavorite=true}
            //});
            kernel.Bind<ICarRepository>().To<EFCarRepository>();
        }

        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
                GameStore.WebUI.Infrastructure.NinjectDependencyResolver(kernel));
        }
    }
}