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
    public partial class StepperSliderPage : ContentPage
    {
        Stepper stp;
        Slider sld;
        Label lbl;
        public StepperSliderPage()
        {
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                Increment = 5
            };
            stp.ValueChanged += Stp_ValueChanged;
            lbl = new Label
            {
                Text = "TTHK",
                FontSize=stp.Value,
            };
            sld = new Slider
            {
                Minimum = stp.Minimum,
                Maximum = stp.Maximum,
                Value = stp.Value,
                MinimumTrackColor=Color.White,
                MaximumTrackColor=Color.Black,
            };
            sld.ValueChanged += Stp_ValueChanged;

            AbsoluteLayout abs = new AbsoluteLayout { Children = { stp, sld, lbl } };
            AbsoluteLayout.SetLayoutBounds(stp, new Rectangle(0.3, 0.2, 300, 100));
            AbsoluteLayout.SetLayoutFlags(stp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(sld, new Rectangle(0.3, 0.4, 300, 100));
            AbsoluteLayout.SetLayoutFlags(sld, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.3, 0.6, 300, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;

        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.FontSize= e.NewValue;
        }
    }
}