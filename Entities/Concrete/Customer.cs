using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Abstract;


namespace Entities.Concrete
{
    public class Customer :IUser
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } 

    }
}
