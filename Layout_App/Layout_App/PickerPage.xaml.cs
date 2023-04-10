using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        Entry entry;
        Button btn;
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
                HeightRequest = 400,
                WidthRequest = 300,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            entry = new Entry { };
            entry.Completed += Entry_Completed;
            btn = new Button { Text = "Go" };
            btn.Clicked += Btn_Clicked;
            st = new StackLayout { Children = { picker, entry, btn, frame } };
            Content = st;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = (string)Preferences.Get("link", "https://www.postimees.ee/") };
        }

        protected override void OnAppearing()
        {
            object link = "";
            entry.Text = Preferences.Get("link", "https://www.postimees.ee/");
            base.OnAppearing();
        }
        private void Entry_Completed(object sender, EventArgs e)
        {
            string value = "https://www." + entry.Text;
            Preferences.Set("link", value);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }
    }
}