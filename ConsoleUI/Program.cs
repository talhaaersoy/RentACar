using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
              CarManager cars = new CarManager(new InMemoryCarDal());
              foreach (var car in cars.GetAll())
              {
                  Console.WriteLine(car.Id);
                 
              }
        }
    }
}
