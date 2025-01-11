using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginDeber
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Dm_registrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Dm_usuario.Text) || string.IsNullOrWhiteSpace(Dm_clave.Text))
            {
                DisplayAlert("ERROR", "Los campos no pueden estar vacíos", "OK");
            }
            else if (Dm_usuario.Text.ToLower() == "admin" && Dm_clave.Text == "12345")
            {
                DisplayAlert("CORRECTO", "TE REGISTRARAS: " + Dm_usuario.Text, "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("ERROR", "Usuario o contraseña incorrectos", "OK");
            }
        }

        private void Dm_login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Dm_usuario.Text) || string.IsNullOrWhiteSpace(Dm_clave.Text))
            {
                DisplayAlert("ERROR", "Los campos no pueden estar vacíos", "OK");
            }
            else if (Dm_usuario.Text.ToLower() == "admin" && Dm_clave.Text == "12345")
            {
                DisplayAlert("CORRECTO", "BIENVENIDO: " + Dm_usuario.Text, "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("ERROR", "Usuario o contraseña incorrectos", "OK");
            }
        }


    }
}