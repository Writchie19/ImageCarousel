using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageCarousel.Server.Models
{
    public class ImageModel
    {
        public IFormFile Image { get; set; }
    }
}
