using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Huella
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void FingerprintIconTapped(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration(
                "Por favor, ponga su dedo.", "");
            FingerprintAuthenticationResult result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                // Mostrar mensaje de bienvenida en un DisplayAlert
                await DisplayAlert("Bienvenido", "Autenticación exitosa", "OK");

                Application.Current.MainPage = new Page1(); 
            }
            else
            {
                await DisplayAlert("ERROR", "Autenticación erroea", "OK");
                Application.Current.MainPage = new MainPage();
            }
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {

            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "Admin" && password == "12345")
            {
                // Credenciales válidas, mostrar mensaje de éxito
                DisplayAlert("Inicio de sesión exitoso", "Bienvenido, Admin", "OK");
                Application.Current.MainPage = new Page1();
            }
            else
            {
                // Credenciales inválidas, mostrar mensaje de error
                DisplayAlert("Error de inicio de sesión", "Credenciales incorrectas", "OK");
                Application.Current.MainPage = new MainPage();
            }
        }


    }
}
