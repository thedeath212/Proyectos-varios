using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = ContraseñaEntry.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor ingresa tu correo electrónico y contraseña.", "OK");
                return;
            }
            Usuario usuario = await App.SQLiteDB.GetUsuarioByEmailAsync(email);

            if (usuario != null && usuario.Contraseña == password)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Correo electrónico o contraseña incorrectos.", "OK");
            }
        }

        private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
    }
}
