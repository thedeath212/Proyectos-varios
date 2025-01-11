using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repaso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContacto : ContentPage
    {
        private ObservableCollection<Contacto> contactos;

        public PageContacto(Contacto contacto, ObservableCollection<Contacto> contactos)
        {
            InitializeComponent();
            BindingContext = contacto;
            this.contactos = contactos; // Guarda la referencia a la colección de contactos
            Dm_btnDelete.Clicked += Dm_btnDelete_Clicked;
            Dm_btnupdate.Clicked += Dm_btnupdate_Clicked;
            Logica.ListasCambiadas += Logica_ListasCambiadas;
        }
        private async void Dm_btnDelete_Clicked(object sender, EventArgs e)
        {
            var contacto = (Contacto)BindingContext;

            // Muestra un cuadro de diálogo de confirmación antes de eliminar
            var confirm = await DisplayAlert("Confirmar", "¿Estás seguro de que quieres eliminar este contacto?", "Sí", "No");
            if (confirm)
            {
                
                int idAEliminar = contacto.Id;
                Logica.EliminarContactoPorId(idAEliminar);
                await DisplayAlert("Éxito", "Contacto eliminado con éxito", "OK");
                await Navigation.PopAsync();
            }
        }
        private void Dm_btnupdate_Clicked(object sender, EventArgs e)
        {
            var contacto = (Contacto)BindingContext;

            // Verifica si la página de actualización ya está en la pila de navegación
            var existingPage = Navigation.NavigationStack.FirstOrDefault(page => page is UpdatePage);

            if (existingPage == null)
            {
                // Crea una instancia de UpdatePage proporcionando el Contacto y la ObservableCollection<Contacto>
                Navigation.PushAsync(new UpdatePage(contacto, contactos));
            }
        }
        private void Logica_ListasCambiadas(object sender, EventArgs e)
        {
            // Notifica a la interfaz de usuario que la colección ha cambiado
            Device.BeginInvokeOnMainThread(() =>
            {
                OnPropertyChanged(nameof(Logica.listaNombres));
            });
        }
        private void Dm_btnAdd_Clicked(object sender, EventArgs e)
        {
            // Abre la página para agregar un nuevo usuario
            Navigation.PushAsync(new AgregarUsuario(contactos));
        }


    }
}