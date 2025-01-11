using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notificaciones
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTextBadge.Text) ||
                string.IsNullOrEmpty(txtTituloBadge.Text))
            {
                return;
            }

            Plugin.LocalNotifications.CrossLocalNotifications.Current
                .Show(txtTituloBadge.Text, txtTextBadge.Text, 0);

            // Notificar al usuario que se ha enviado la notificación
            DisplayAlert("Notificación enviada", "Se ha enviado la notificación.", "OK");
        }
    }
}
