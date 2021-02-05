using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager cars = new CarManager(new EfCarDal());
            foreach (var car in cars.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
