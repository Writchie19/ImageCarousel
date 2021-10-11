using Carter;
using Carter.ModelBinding;
using Carter.Response;
using ImageCarousel.Server.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageCarousel.Server.EndPoints
{
    public class Images : CarterModule
    {
        public Images()
        {
            Get("/api/images", GetImages);
            Post("/api/images", SetImage);
        }

        private async Task SetImage(HttpRequest req, HttpResponse res)
        {
            //var result = await req.BindAndSaveFile("C:/Users/willr/Documents/ImageCarousel/", "test.jpg");
            var result = await req.BindFile();
            if (result == null)
            {
                res.StatusCode = 500;
                return;
            }
            var saveLocation = "C:/Users/willr/Documents/ImageCarousel/";
            var fileName = "test.jpg";
            if (!Directory.Exists(saveLocation))
                Directory.CreateDirectory(saveLocation);

            fileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : result.FileName;

            using (var fileToSave = File.Create(Path.Combine(saveLocation, fileName)))
                await result.CopyToAsync(fileToSave);
            //var (result, data) = await req.BindAndValidate<ImageModel>();
            //if (result.IsFaulted)
            //{
            //    res.StatusCode = 422;
            //    await res.Negotiate(result.GetFormattedErrors());
            //    return;
            //}

            // Save image

            res.StatusCode = 200;
        }

        private async Task GetImages(HttpRequest req, HttpResponse res)
        {
            res.StatusCode = 200;
            await res.AsJson("Success");
        }
    }
}
