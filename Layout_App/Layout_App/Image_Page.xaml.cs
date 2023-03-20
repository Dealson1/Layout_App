using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layout_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Image_Page : ContentPage
    {
        Switch sw;
        Image img, img2;
        public Image_Page()
        {
            img = new Image { Source = "pepe.jpg" };
            img2 = new Image { Source = "cry.png" };

            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
            };
            sw.Toggled += Sw_Toggled;

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            this.Content = new StackLayout { Children = { img, sw } };
        }

        int tappid;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            tappid++;
            var imagesender = (Image)sender;
            if (tappid % 2==0)
            {
                img.Source = "cry.png";
            }
            else
            {
                img.Source = "pepe.jpg";
            }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}