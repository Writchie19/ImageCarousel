using Carter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageCarousel.Server.EndPoints
{
    public class Images : CarterModule
    {
        public ImagesModule()
        {
            Get("/api/images")
        }
    }
}
