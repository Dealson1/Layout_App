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

            AbsoluteLayout abs = new AbsoluteLayout { Children = { redSlider, greenSlider, blueSlider, box} };
            AbsoluteLayout.SetLayoutBounds(redSlider, new Rectangle(0.3, 0.5, 300, 100));
            AbsoluteLayout.SetLayoutFlags(redSlider, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(greenSlider, new Rectangle(0.3, 0.6, 300, 100));
            AbsoluteLayout.SetLayoutFlags(greenSlider, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(blueSlider, new Rectangle(0.3, 0.7, 300, 100));
            AbsoluteLayout.SetLayoutFlags(blueSlider, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
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