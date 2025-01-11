using System;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Repaso
{
    public partial class UpdatePage : ContentPage
    {
        private Contacto contacto;
        private ObservableCollection<Contacto> contactos;

        // Evento para notificar la actualización
        public event EventHandler<Contacto> ContactoActualizado;

        // Declarar los Entry como campos de clase
        private Entry entryNuevoNombre;
        private Entry entryNuevaDireccion;
        private Entry entryNuevoTelefono;

        public UpdatePage(Contacto contacto, ObservableCollection<Contacto> contactos)
        {
            InitializeComponent();
            this.contacto = contacto;
            this.contactos = contactos;

            // Establece el contexto de enlace al contacto actual
            BindingContext = contacto;

            // Inicializa los Entry
            entryNuevoNombre = new Entry { Placeholder = "Nuevo nombre", Text = contacto.Nombre };
            entryNuevaDireccion = new Entry { Placeholder = "Nueva dirección", Text = contacto.Direccion };
            entryNuevoTelefono = new Entry { Placeholder = "Nuevo teléfono", Text = contacto.Telefono };

            var btnActualizar = new Button { Text = "Actualizar" };
            btnActualizar.Clicked += BtnActualizar_Clicked;

            var layout = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    entryNuevoNombre,
                    entryNuevaDireccion,
                    entryNuevoTelefono,
                    btnActualizar
                }
            };

            Content = layout;
        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            // Actualiza el contacto con los nuevos valores
            contacto.Nombre = entryNuevoNombre.Text;
            contacto.Direccion = entryNuevaDireccion.Text;
            contacto.Telefono = entryNuevoTelefono.Text;

            // Notifica la actualización mediante el evento
            ContactoActualizado?.Invoke(this, contacto);

            // Muestra una alerta indicando que el contacto ha sido actualizado
            DisplayAlert("Actualización", "Contacto actualizado", "OK");

            // Cierra la página de actualización después de actualizar
            Navigation.PopAsync();
        }
    }
}