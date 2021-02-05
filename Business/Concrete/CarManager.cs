using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(c => c.ColorId == colorId);
        }

        public void Add(Car car)
        {
            var context = new ValidationContext(car);
            var validationResult = new List<ValidationResult>();

            bool isValid6 = Validator.TryValidateObject(car, context, validationResult, true);
            if (!isValid6)
            {
                Console.WriteLine(validationResult);
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

        public void update(Car car)
        {
            _iCarDal.Update(car);
        }
    }
}
