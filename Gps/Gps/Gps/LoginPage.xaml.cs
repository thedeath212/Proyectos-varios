using Gps.Datos;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gps
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Verifica si el usuario y la contraseña son iguales a "don" y "123" respectivamente
            if (username == "don" && password == "123")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Si las credenciales no son válidas, muestra un mensaje de error
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }




        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegistroPage());
        }
    }
}
