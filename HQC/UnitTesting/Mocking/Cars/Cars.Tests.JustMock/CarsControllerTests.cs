namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        // : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeitailsShouldThrowsAnExceptionWhenThereIsNoCarWithThatId()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(0));
        }

        [TestMethod]
        public void DetailsShouldReturnProperCarIfValidIdPassed()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchShouldReturnAllCarsWithSameMakeOrModelAsPassedOne()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("MakeOrModel"));

            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortShouldThrowsAnExceptionWhenPassedInValidSortingParram()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("invalid"));
        }

        [TestMethod]
        public void SortShouldReturnAllCarsSortedByMakeWhenPassedMakeAsParram()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void SortShouldReturnAllCarsSortedByYearWhenPassedYearAsParram()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, model.Count);
        }


        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
