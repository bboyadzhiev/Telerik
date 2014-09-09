﻿namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Collections.Generic;

    public abstract class CarRepositoryMock : ICarsRepositoryMock
    {
        public CarRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public ICarsRepository CarsData { get; protected set; }

        protected ICollection<Car> FakeCarCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeCarCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2014 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
                new Car { Id = 5, Make = "Seat", Model = "Toledo", Year = 1990 },
                new Car { Id = 6, Make = "Volkswagen", Model = "Golf", Year = 1991 },
            };
        }

        protected abstract void ArrangeCarsRepositoryMock();
    }
}