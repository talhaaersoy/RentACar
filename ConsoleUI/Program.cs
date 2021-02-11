using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarsManagerTest();

           RentalManager rentalManager = new RentalManager(new EfRentalDal());
           
               rentalManager.Add(new Rental
               {
                   CarId = 2,
                   CustomerId = 2,

               });
            
       

        }

        private static void CarsManagerTest()
        {
            CarManager cars = new CarManager(new EfCarDal());
            try
            {
                cars.Add(new Car
                {
                    BrandId = 1,
                    ColorId = 2,
                    DailyPrice = 250,
                    Description = "Dizel",
                    ModelYear = 2010,
                    Name = "E300"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.WriteLine("-----------");
            foreach (var car in cars.GetCarDetails().Data)
            {
                Console.WriteLine($"Car Name : {car.BrandName +" "+ car.CarName }");
            }
            Console.WriteLine("-----------");
            foreach (var car in cars.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine($"Car name : {car.CarName} ");
            }
            Console.WriteLine("----------");
        }
    }
}
