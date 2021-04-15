using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

    [SecuredOperation("Customer,Admin")]

    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if (result == null)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult("Fotoğraf Başarıyla Eklendi");
            }
            return result;
            
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
           
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        public IResult CheckIfImageLimitExceded(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if(result.Count >= 5)
            {
                return new ErrorResult("En fazla 5 tane fotoğraf yüklenebilir.");
            }
            return new SuccessResult();
        }
        public List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"C:\Users\mtalh\OneDrive\Masaüstü\Engin Demirog\ReCapProject\WebAPI\wwwroot\images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}
