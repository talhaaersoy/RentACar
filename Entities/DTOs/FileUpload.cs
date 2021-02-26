using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
        public int CarId { get; set; }
    }
}
