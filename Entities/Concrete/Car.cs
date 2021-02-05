using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        [Range(0, 1000000, ErrorMessage = "Araba fiyatı sıfırdan fazla olmalı")]
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
