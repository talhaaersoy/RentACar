using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
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


        public IDataResult<List<Car>> GetAll()
        {
            return  new SuccessDataResult<List<Car>>(_iCarDal.GetAll());
        }

        public IDataResult<Car> GetByCarId(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IResult Add(Car car)
        {
            var context = new ValidationContext(car);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(car, context, validationResult, true);
            if (!isValid)
            {
                foreach (var v in validationResult)
                {
                    return new ErrorResult(v.ToString());
                }

                return null;
            }
            else
            {
               _iCarDal.Add(car);
               return new SuccessResult();
            }
        }

        public IResult Delete(Car car)
        {
           _iCarDal.Delete(car);
           return new SuccessResult();

        }

        public IResult Update(Car car)
        {
            var context = new ValidationContext(car);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(car, context, validationResult, true);
            if (!isValid)
            {
                foreach (var v in validationResult)
                {
                    return new ErrorResult(v.ToString());
                }

                return null;
            }
            else
            {
                _iCarDal.Update(car);
                return new SuccessResult();
            }
        }
    }
}
