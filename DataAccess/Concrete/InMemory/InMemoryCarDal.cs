using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 500,Description = "Benzin&Lpg",ModelYear = 2005},
                new Car{Id = 2,BrandId = 2,ColorId = 1,DailyPrice = 1000,Description = "Benzin",ModelYear = 2011},
                new Car{Id = 3,BrandId = 3,ColorId = 3,DailyPrice = 1500,Description = "Benzin&Lpg",ModelYear = 2010},
                new Car{Id = 4,BrandId = 4,ColorId = 2,DailyPrice = 2000,Description = "Dizel",ModelYear = 2020},
                new Car{Id = 5,BrandId = 5,ColorId = 2,DailyPrice = 300,Description = "Benzin&Lpg",ModelYear = 2000}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Update(Car car)
        {
           var c = _cars.FirstOrDefault(a => a.Id == car.Id);
           c.BrandId = car.BrandId;
           c.ColorId = car.ColorId;
           c.DailyPrice = car.DailyPrice;
           c.Description = car.Description;
           c.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            var c = _cars.FirstOrDefault(a => a.Id == car.Id);
            _cars.Remove(c);

        }
    }
}
