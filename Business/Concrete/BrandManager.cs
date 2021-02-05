using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;

        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
        public void Add(Brand brand)
        {
            var context = new ValidationContext(brand);
            var validationResult = new List<ValidationResult>();

            bool isValid6 = Validator.TryValidateObject(brand, context, validationResult, true);
            if (!isValid6)
            {
                Console.WriteLine(validationResult);
            }
            else
            {
                _brandDal.Add(brand);
            }
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
