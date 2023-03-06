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
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
        }

        private async void Tagasi_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        int i = 0;

        private async void NaitaAeg()
        {
            while (true)
            {
                lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            i++;
            
            if (i >= 10)
            {
                NaitaAeg();
            }
            else
            {
                lbl.Text = "Vajutatud " + i.ToString() + " korda";
            };
        }
    }
}