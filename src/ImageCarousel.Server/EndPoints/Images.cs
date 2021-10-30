using Carter;
using Carter.ModelBinding;
using Carter.Response;
using ImageCarousel.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageCarousel.Server.EndPoints
{
    public class Images : CarterModule
    {
        private readonly ILogger _logger;
        public Images(ILogger<Images> logger)
        {
            _logger = logger;
            Get("/api/images", GetImages);
            Post("/api/images", SetImage);
        }

        private async Task SetImage(HttpRequest req, HttpResponse res)
        {
            //var result = await req.BindAndSaveFile("C:/Users/willr/Documents/ImageCarousel/", "test.jpg");
            try
            {
                var result = await req.BindFile();
                if (result == null)
                {
                    res.StatusCode = 500;
                    return;
                }

                var saveLocation = "C:/ImageCarousel/Photos/";
                //var fileName = $"Photo-{DateTime.Now:yyyy-MM-ddTHH-mm-ss-fffffffK}-{Guid.NewGuid()}.jpg";
                var fileName = $"Photo-{Guid.NewGuid()}.jpg";

                Directory.CreateDirectory(saveLocation);

                fileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : result.FileName;

                using var fileToSave = File.Create(Path.Combine(saveLocation, fileName));
                await result.CopyToAsync(fileToSave);

                _logger.LogInformation($"Saving file: {fileName} to path: {saveLocation}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.LogError("Failed to save in coming file");
                res.StatusCode = 500;
                return;
            }

            res.StatusCode = 200;
        }

        private async Task GetImages(HttpRequest req, HttpResponse res)
        {
            res.StatusCode = 200;
            await res.AsJson("Success");
        }
    }
}
