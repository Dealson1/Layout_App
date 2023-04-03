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
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webview;
        Frame frame;
        string[] lehed = new string[4] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://thk.edupage.org/timetable/" };
        StackLayout st;
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Lehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Timetable");
            webview = new WebView { Source = new UrlWebViewSource { Url = lehed[0] } };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            frame = new Frame
            {
                Content = webview,
                BorderColor = Color.Beige,
                CornerRadius = 10,
                HeightRequest = 500,
                WidthRequest = 300,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            st = new StackLayout { Children = { picker, frame } };
            Content = st;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }
    }
}