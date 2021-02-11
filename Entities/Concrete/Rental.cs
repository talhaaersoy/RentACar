using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Rental : IUser
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
