using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentCar.Domain.Abstract;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RentCar.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Cars()
        {
            Mock<ICarRepository> mock = new Mock<ICarRepository>();
            mock.Setup(m => m.Cars).Returns(new List<Car>
            {
                new Car {}
            });
        }
    }
}
