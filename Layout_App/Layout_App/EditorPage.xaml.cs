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
    public partial class EditorPage : ContentPage
    {
        Editor editor;
        Button tagasi_btn;
        Label lbl;
        public EditorPage()
        {
            editor = new Editor
            {
                TextColor= Color.OrangeRed,
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.Gray
            };

            editor.TextChanged += Editor_TextChanged;

            lbl = new Label
            {
                Text ="...",
                TextColor= Color.OrangeRed,
                BackgroundColor= Color.White,
            };

            tagasi_btn = new Button { Text = "Tagasi" };
            tagasi_btn.Clicked += Tagasi_btn_Clicked;
            StackLayout stack = new StackLayout
            { 
                Children= {editor, lbl, tagasi_btn } 
            };

            stack.BackgroundColor = Color.LightGray;
            Content= stack;
        }

        int i = 0;

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lbl.Text = editor.Text;
            editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'A' || key == 'a')
            {
                i++;
                lbl.Text = key.ToString() + ": " + i;
            }
            editor.TextChanged += Editor_TextChanged;
        }

        private async void Tagasi_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}