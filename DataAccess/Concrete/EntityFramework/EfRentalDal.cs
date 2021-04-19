using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,RecapContext>,IRentalDal
    {
        public List<RentalDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from r in context.Rentals 
                             join c in context.Cars 
                             on r.CarId equals c.Id
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id 
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 CarName = c.Name,
                                 CustomerName = cs.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
