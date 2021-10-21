﻿using Carter;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
