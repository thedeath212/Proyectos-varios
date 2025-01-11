using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WSPI.ViewModel
{
    public class LoginViewModel
    {
        public String NombreUsuario { get; set; }
        public String Contraseña { get; set; }

        public bool IsRunning { get; set; }

        public ICommand IniciarSesionCommand 
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            await Application.Current.MainPage.DisplayAlert
                ("Ok", "Hola 4to", "Aceptar");
            return;
        }
    }
}
