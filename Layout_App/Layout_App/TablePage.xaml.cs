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
    public partial class TablePage : ContentPage
    {
        TableView table;
        SwitchCell sc;
        ImageCell ic;
        TableSection foto;

        public TablePage()
        {
            sc =new SwitchCell { Text = "Näita veel"};
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("pepe.jpg"),
                Text = "Foto nimetus",
                Detail = "Kirjeldus"
            };
            foto = new TableSection();

            table = new TableView
            {
                Intent= TableIntent.Form,
                Root=new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        new EntryCell
                        {
                            Label="Nimi: ",
                            Placeholder="Sisesta nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Konaktiandmed")
                    {
                        new EntryCell
                        {
                            Label="Telefon: ",
                            Placeholder="Sisesta oma telefoni nr",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email: ",
                            Placeholder="Sisesta email",
                            Keyboard=Keyboard.Email
                        },
                        sc
                    },
                    foto
                }
            };
            Content= table;
        }

        private void Sc2_OnChanged(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                foto.Title = "Foto";
                foto.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                foto.Title = "";
                foto.Remove(ic);
                sc.Text = "Näita";
            }
        }
    }
}