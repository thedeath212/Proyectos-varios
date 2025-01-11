using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilClases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Dm_registrar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("CORRECTO", "TE REGISTRARAS: " + Dm_usuario.Text, "OK");
            Navigation.PushAsync(new Page1());
        }

        private void Dm_login_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("CORRECTO", "BIENVENIDO:   " + Dm_usuario.Text, "OK");
            Navigation.PushAsync(new Page1());
        }
    }
    
}
