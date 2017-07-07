using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShanePrototypeXamarin
{
    public partial class ImageExperimentPage : ContentPage
    {
        public ImageExperimentPage()
        {
            InitializeComponent();

            var iamgeSource = new UriImageSource { Uri = new Uri("http://lorempixel.com/1920/1080/sports/7/") };
            iamgeSource.CachingEnabled = false;
            image.Source = iamgeSource;
        }
    }
}
