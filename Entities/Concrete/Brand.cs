using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        [MinLength(2,ErrorMessage = "Araba ismi minimum 2 karakter olmalı")]
        public string Name { get; set; }
    }
}
