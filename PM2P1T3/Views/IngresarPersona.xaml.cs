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
    public partial class IngresarPersona : ContentPage
    {
        public IngresarPersona()
        {
            InitializeComponent();
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
                    Id = 0,
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
                    answer = await DisplayAlert("Aviso", "Persona adicionada con éxito.\n\n¿Vaciar el formulario?", "Si", "No");
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
            else{ await DisplayAlert("Aviso", "Llene todos los campos", "OK"); }
        }

        private async void btnverlistapersonas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPersonas());
        }
    }
}