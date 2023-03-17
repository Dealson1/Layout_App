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
    public partial class Valgusfoor : ContentPage
    {
        Label Redlabel, Yellowlabel, Greenlabel;
        Frame Redframe, Yellowframe, Greenframe;
        Button Onbtn, Offbtn;
        bool work = false;

        public Valgusfoor()
        {
            Redlabel = new Label
            {
                Text = "Красный",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            Yellowlabel = new Label
            {
                Text = "Желтый",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            Greenlabel = new Label
            {
                Text = "Зеленый",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            Redframe = new Frame
            {
                Content = Redlabel,
                BackgroundColor = Color.LightPink,
                CornerRadius = 100,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            Yellowframe = new Frame
            {
                Content = Yellowlabel,

                BackgroundColor = Color.LightGoldenrodYellow,
                CornerRadius = 100,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            Greenframe = new Frame
            {
                Content = Greenlabel,
                BackgroundColor = Color.LightGreen,
                CornerRadius = 100,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            Onbtn = new Button
            {
                Text = "On",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End

            };

            Offbtn = new Button
            {
                Text = "Off",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };

            Onbtn.Clicked += Btn1_Clicked;
            Offbtn.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { Redframe, Yellowframe, Greenframe, Onbtn, Offbtn }
            };

            Content = st;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            TapGestureRecognizer tap3 = new TapGestureRecognizer();

            tap.Tapped += Tap_Tapped;
            tap2.Tapped += Tap2_Tapped;
            tap3.Tapped += Tap3_Tapped;

            Redframe.GestureRecognizers.Add(tap);
            Yellowframe.GestureRecognizers.Add(tap2);
            Greenframe.GestureRecognizers.Add(tap3);


        }

        private void Tap3_Tapped(object sender, EventArgs e)
        {
            if (work)
            {
                if (Greenframe.BackgroundColor == Color.Green)
                {
                    Greenlabel.Text = "Едьте";
                }
                else if (Greenframe.BackgroundColor == Color.LightGreen)
                {
                    Greenlabel.Text = "Зеленый";
                }

            }
            else
            {
                Greenlabel.Text = "Светофор выключен";
            }
        }

        private void Tap2_Tapped(object sender, EventArgs e)
        {
            if (work)
            {
                if (Yellowframe.BackgroundColor == Color.Yellow)
                {
                    Yellowlabel.Text = "Готовьтесь";
                }
                else if (Yellowframe.BackgroundColor == Color.LightGoldenrodYellow)
                {
                    Yellowlabel.Text = "Желтый";
                }

            }
            else
            {
                Yellowlabel.Text = "Светофор выключен";
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (work)
            {
                if (Redframe.BackgroundColor == Color.Red)
                {
                    Redlabel.Text = "Стоп";
                }
                else if (Redframe.BackgroundColor == Color.LightPink)
                {
                    Redlabel.Text = "Красный";
                }

            }
            else
            {
                Redlabel.Text = "Светофор выключен";
            }
        }

        private async void Btn2_Clicked(object sender, EventArgs e)
        {
            work = false;
            Redlabel.Text = "Красный";
            Yellowlabel.Text = "Желтый";
            Greenlabel.Text = "Зеленый";

            while (work)
            {

                this.BackgroundColor = Color.White;
                Redframe.BackgroundColor = Color.Gray;
                await Task.Delay(100);
                Yellowframe.BackgroundColor = Color.Gray;
                await Task.Delay(100);
                Greenframe.BackgroundColor = Color.Gray;
                await Task.Delay(100);
            }
        }

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            work = true;
            if (work)
            {
                Redlabel.Text = "Красный";
                Yellowlabel.Text = "Желтый";
                Greenlabel.Text = "Зеленый";
            }
            if (Redframe.BackgroundColor == Color.Gray)
            {
                Redlabel.Text = "Красный";
            }
            if (Yellowframe.BackgroundColor == Color.Gray)
            {
                Yellowlabel.Text = "Желтый";
            }
            if (Redframe.BackgroundColor == Color.Gray)
            {
                Greenlabel.Text = "Зеленый";
            }

            while (work)
            {

                Redframe.BackgroundColor = Color.Red;
                await Task.Delay(3000);

                Redframe.BackgroundColor = Color.LightPink;
                Yellowframe.BackgroundColor = Color.Yellow;
                Yellowlabel.TextColor = Color.Black;
                await Task.Delay(2000);

                Yellowlabel.TextColor = Color.White;
                Yellowframe.BackgroundColor = Color.LightGoldenrodYellow;
                Greenframe.BackgroundColor = Color.Green;
                await Task.Delay(3000);

                Greenframe.BackgroundColor = Color.LightGreen;
                await Task.Delay(500);

                Greenframe.BackgroundColor = Color.Green;
                await Task.Delay(500);

                Greenframe.BackgroundColor = Color.LightGreen;
                await Task.Delay(500);

                Greenframe.BackgroundColor = Color.Green;
                await Task.Delay(500);

                Greenframe.BackgroundColor = Color.LightGreen;
            }

        }
    }
}