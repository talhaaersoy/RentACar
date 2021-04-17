using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RecapContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join cl in context.Colors
                        on c.ColorId equals cl.Id
                    select new CarDetailDto
                    {
                        CarId = c.Id,
                        BrandName = b.Name,
                        ColorName = cl.Name,
                        CarName = c.Name,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();

            }
        }
    }
}
