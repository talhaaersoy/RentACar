using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }


        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public Car GetByCarId(int id)
        {
            return _iCarDal.Get(c => c.Id == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public void Add(Car car)
        {
            var context = new ValidationContext(car);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(car, context, validationResult, true);
            if (!isValid)
            {
                foreach (var v in validationResult)
                {
                    Console.WriteLine(v.ToString());
                }
            }
            else
            {
                _iCarDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
           _iCarDal.Delete(car);

        }

        public void Update(Car car)
        {
            var context = new ValidationContext(car);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(car, context, validationResult, true);
            if (!isValid)
            {
                foreach (var v in validationResult)
                {
                    Console.WriteLine(v.ToString());
                }
            }
            else
            {
                _iCarDal.Update(car);
            }
        }
    }
}
