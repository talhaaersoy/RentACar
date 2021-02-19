using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

          
            ValidationTool.Validate(new CarValidator(), car);
               _iCarDal.Add(car);
               return new SuccessResult();
           
        }

        public IResult Delete(Car car)
        {
           _iCarDal.Delete(car);
           return new SuccessResult();

        }

        public IResult Update(Car car)
        {
           
           
                _iCarDal.Update(car);
                return new SuccessResult();
           
        }
    }
}
