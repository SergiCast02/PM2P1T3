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
    public partial class ListaPersonas : ContentPage
    {
        personas person;
        public ListaPersonas()
        {
            InitializeComponent();
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            actualizar();
        }

        private void ListaPersona_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            person = (personas)e.Item;
            btnactualizarpersona.IsEnabled = true;
            btneliminarpersona.IsEnabled = true;
            btnverpersona.IsEnabled = true;
        }

        private async void btnactualizarpersona_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Modificar(person));
        }

        private async void btneliminarpersona_Clicked(object sender, EventArgs e)
        {
            var result = await App.DBase.PersonDelete(person);
            if(result == 1)
            {
                await DisplayAlert("Aviso", "Persona eliminada correctamente", "OK");
                actualizar();
            }
            else
            {
                await DisplayAlert("Aviso", "No se pudo eliminar la persona", "OK");
            }
        }

        private async void btnverpersona_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Persona",
                "Nombres: " + person.Nombres + "\n" +
                "Apellidos: " + person.Apellidos + "\n" +
                "Edad: " + person.Edad + "\n" +
                "Correo: " + person.Correo + "\n" +
                "Dirección: " + person.Direccion, "OK");
        }

        async void actualizar()
        {
            ListaPersona.ItemsSource = await App.DBase.obtenerListaPerson();
            btnactualizarpersona.IsEnabled = false;
            btneliminarpersona.IsEnabled = false;
            btnverpersona.IsEnabled = false;
        }
    }
}