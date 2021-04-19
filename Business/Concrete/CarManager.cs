using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
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

       
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return  new SuccessDataResult<List<Car>>(_iCarDal.GetAll());
        }
        [SecuredOperation("Customer")]
        [CacheAspect]
        public IDataResult<Car> GetByCarId(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == id));
        }
        [SecuredOperation("Customer")]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.BrandId == brandId));
        }
        [SecuredOperation("Customer")]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        }
        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }
        [SecuredOperation("Admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

          
            ValidationTool.Validate(new CarValidator(), car);
               _iCarDal.Add(car);
               return new SuccessResult();
           
        }
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarService.Get")] 
        public IResult Delete(Car car)
        {
           _iCarDal.Delete(car);
           return new SuccessResult();

        }
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
           
           
                _iCarDal.Update(car);
                return new SuccessResult();
           
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 250)
            {
                throw new Exception("");

            }
            Add(car);
            return null;
        }
    }
}
