using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Repaso
{
    public partial class AgregarUsuario : ContentPage
    {
        private ObservableCollection<Contacto> contactos;

        public AgregarUsuario(ObservableCollection<Contacto> contactos)
        {
            InitializeComponent();
            this.contactos = contactos;
        }

        private void GuardarUsuario_Clicked(object sender, EventArgs e)
        {
            string nombre = NombreEntry.Text;
            string apellido = ApellidoEntry.Text;
            string direccion = DireccionEntry.Text;
            string telefono = TelefonoEntry.Text;

            int nuevoId = ObtenerNuevoId();

            Contacto nuevoUsuario = new Contacto()
            {
                Id = nuevoId,
                Nombre = $"{nombre} {apellido}",
                Direccion = direccion,
                Telefono = telefono
            };

            contactos.Add(nuevoUsuario);

            DisplayAlert("Éxito", "Usuario agregado con éxito", "OK");
            Navigation.PopAsync();
        }
        private int ObtenerNuevoId()
        {
            return contactos.Any() ? contactos.Max(c => c.Id) + 1 : 1;
        }
    }
}
