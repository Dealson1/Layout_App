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
        Label redLbl, greenLbl, blueLbl, alphalbl;
        Slider redSld, greenSld, blueSld;
        Stepper alphaStp;

        Xamarin.Forms.Button btn;
        BoxView box;

        public RGB_Page()
        {
            redLbl = new Label { Text = "Red = ", HorizontalOptions = LayoutOptions.Center };
            greenLbl = new Label { Text = "Green = ", HorizontalOptions = LayoutOptions.Center };
            blueLbl = new Label { Text = "Blue = ", HorizontalOptions = LayoutOptions.Center };
            alphalbl = new Label { Text = "Прозрачность = ", HorizontalOptions = LayoutOptions.Center };

            box = new BoxView()
            {
                Color = Color.Black,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            redSld = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,

                MinimumTrackColor = Color.LightPink,
                MaximumTrackColor = Color.Red,
            };

            redSld.ValueChanged += OnSlideValueChanged;

            greenSld = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,

                MinimumTrackColor = Color.LightGreen,
                MaximumTrackColor = Color.Green,
            };
            greenSld.ValueChanged += OnSlideValueChanged;

            blueSld = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,
                MinimumTrackColor = Color.LightBlue,
                MaximumTrackColor = Color.Blue
            };
            blueSld.ValueChanged += OnSlideValueChanged;

            alphaStp = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 5,
                Value = 255,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            alphaStp.ValueChanged += OnSlideValueChanged;

            btn = new Xamarin.Forms.Button
            {
                Text = "Random",
            };
            btn.Clicked += Btn_Clicked;

            StackLayout st = new StackLayout { Children = { box, redSld, redLbl, greenSld, greenLbl, blueSld, blueLbl, alphaStp, alphalbl, btn } };
            Content = st;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            redSld.Value= rnd.Next(0, 255);
            greenSld.Value= rnd.Next(0, 255);
            blueSld.Value= rnd.Next(0, 255);
        }

        private void OnSlideValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == redSld)
            {
                redLbl.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == greenSld)
            {
                greenLbl.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == blueSld)
            {
                blueLbl.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }
            else if (sender == alphaStp)
            {
                alphalbl.Text = String.Format("Прозрачность = {0:X2}", (int)e.NewValue);
            }

            box.Color = Color.FromRgba((int)redSld.Value,
                                      (int)greenSld.Value,
                                      (int)blueSld.Value,
                                      (int)alphaStp.Value);
        }
    }
}
