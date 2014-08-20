namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
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

            Assert.AreEqual(6, model.Count);
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
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2014, model.Year);
            

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByIdMustThrowAnExceptionIfCarIsNotFound()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(150));
        }

        [TestMethod]
        public void SearchShouldReturnAllCarrsIfCarNotFound()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search(""));
            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByInvalidParameterShouldThrowArgumentException()
        {
            var model = (Car)this.GetModel(() => this.controller.Sort("Boeing"));
        }

        [TestMethod]
        public void SortByMakeTest()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));
            Assert.AreEqual("Volkswagen", model.Last().Make);
        }

        [TestMethod]
        public void SortByYearTest()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));
            Assert.AreEqual(2014, model.Last().Year);
        }
        
        /// <summary>
        /// Should throw an exception because current unit tests don't allow: 
        /// - adding of a car
        /// - setting a CarsRepository for the new controller if it isn't set in its parameterized constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarsControllerDefaultConstructorTest()
        {
           
            this.controller = new CarsController();
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());
       
         
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
