using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;


            await DisplayAlert("Registro exitoso", "Usuario registrado correctamente", "OK");
        }
    }
}