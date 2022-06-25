using PM2P1T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1T3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        public Modificar()
        {
            InitializeComponent();
        }

        public Modificar(personas person)
        {
            InitializeComponent();
            Id.Text = ""+person.Id;
            Nombres.Text = person.Nombres;
            Apellidos.Text = person.Apellidos;
            Edad.Text = ""+person.Edad;
            Correo.Text = person.Correo;
            Direccion.Text = person.Direccion;
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            bool flag = false;
            if (String.IsNullOrWhiteSpace(Nombres.Text)) { flag = true; }
            if (String.IsNullOrWhiteSpace(Apellidos.Text)) { flag = true; }
            if (String.IsNullOrWhiteSpace(Edad.Text)) { flag = true; }
            if (String.IsNullOrWhiteSpace(Correo.Text)) { flag = true; }
            if (String.IsNullOrWhiteSpace(Direccion.Text)) { flag = true; }

            if (!flag)
            {
                var person = new personas
                {
                    Id = Int32.Parse(Id.Text),
                    Nombres = Nombres.Text,
                    Apellidos = Apellidos.Text,
                    Edad = Int32.Parse(Edad.Text),
                    Correo = Correo.Text,
                    Direccion = Direccion.Text
                };

                var result = await App.DBase.PersonSave(person);
                bool answer = false;
                if (result > 0)
                {
                    await DisplayAlert("Aviso", "Persona actualizada con éxito", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }

                if (answer)
                {
                    Nombres.Text = null;
                    Apellidos.Text = null;
                    Edad.Text = null;
                    Correo.Text = null;
                    Direccion.Text = null;
                }
            }
            else { await DisplayAlert("Aviso", "Llene todos los campos", "OK"); }
        }
    }
}