using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageCarousel2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SourceImageDirectory = "C:\\ImageCarousel\\Photos";
        private Carousel ImageCarousel;
        private bool IsRunning = true;
        public MainWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory(SourceImageDirectory);
            ImageCarousel = new Carousel(Directory.EnumerateFiles(SourceImageDirectory));
            img.Source = ImageCarousel.CurrentImage;
            Task.Run(async () => {
                await RotateImages(img);
            });
/*            Task.Run(async () => {
                await CheckForImages();
            });*/
        }

        internal async Task RotateImages(Image image)
        {
            while (IsRunning)
            {
                await Task.Delay(4000);
                image.Dispatcher.Invoke(() =>
                {
                    ImageCarousel.NextImage();
                    image.Source = ImageCarousel.CurrentImage;
                });
            }
        }

/*        internal async Task CheckForImages()
        {
            while (IsRunning)
            {
                await Task.Delay(10000);
                var files = Directory.EnumerateFiles(SourceImageDirectory);
                if (files.Count() != ImageCarousel.Images.Count())
                {
                    var photos = files.Except(ImageCarousel.ImageFilesPaths);
                    ImageCarousel.AddImages(photos);
                }
            }
        }*/

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsRunning = false;
        }
    }
}
