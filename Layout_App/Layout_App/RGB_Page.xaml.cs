using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace Layout_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB_Page : ContentPage
    {
        Label redLabel, greenLabel, blueLabel;
        BoxView box;
        Slider redSlider, greenSlider, blueSlider;

        public RGB_Page()
        {
            int r = 0, g = 0, b = 0;
            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 0,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 255,

            };
            redSlider.ValueChanged += RedSlider_ValueChanged;
            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 255,

            };
            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 255,

            };


            redLabel = new Label { Text = "Red = ", HorizontalOptions = LayoutOptions.Center };
            greenLabel = new Label { Text = "Green = ", HorizontalOptions = LayoutOptions.Center };
            blueLabel = new Label { Text = "Blue = ", HorizontalOptions = LayoutOptions.Center };

            StackLayout st = new StackLayout { Children = { box, redSlider, greenSlider, blueSlider, redLabel, greenLabel, blueLabel} };
            Content = st;
        }

        private void RedSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            box.Color = Color.FromRgb(
                (int)redSlider.Value,
                (int)greenSlider.Value,
                (int)blueSlider.Value);
        }
    }
}