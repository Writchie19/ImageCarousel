using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageCarousel2
{
    public class Carousel
    {
        public IEnumerable<BitmapImage> Images { get; set; }
        public BitmapImage CurrentImage { get; set; }
        public int CurrentIndex;
        public IEnumerable<string> ImageFilesPaths { get; set; }

        public Carousel (IEnumerable<string> imagePaths)
        {
            ImageFilesPaths = imagePaths.Where(file => File.Exists(file));
            SetImages(imagePaths);
            CurrentIndex = 0;
            CurrentImage = Images.FirstOrDefault();
        }

        public void SetImages(IEnumerable<string> imagePaths)
        {
            ImageFilesPaths = imagePaths.Where(file => File.Exists(file));
            Images = imagePaths
                .Where(file => File.Exists(file))
                .Select(file => new BitmapImage(new Uri(file)));
        }

        public void AddImage(string imagePath)
        {
            if (!File.Exists(imagePath)) return;
            ImageFilesPaths.Append(imagePath);
            Images.Append(new BitmapImage(new Uri(imagePath)));
        }

        public void AddImages(IEnumerable<string> imagePaths)
        {
            ImageFilesPaths.Concat(imagePaths.Where(file => File.Exists(file)));
            Images.Concat(imagePaths
                .Where(file => File.Exists(file))
                .Select(file => new BitmapImage(new Uri(file))));
        }

        public void NextImage()
        {
            if (Images.Any())
            {
                CurrentIndex = CurrentIndex < Images.Count() - 1? CurrentIndex + 1 : 0;
                CurrentImage = Images.ElementAt(CurrentIndex);
            }

        }
    }
}
