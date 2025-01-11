using SQLite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenarDatos();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validaDatos())
            {
                Usuario usuario = new Usuario
                {
                    Nombre = nombreEntry.Text,
                    Apellido = apellidoEntry.Text,
                    Email = emailEntry.Text,
                    Contraseña = contraseñaEntry.Text,
                    User = usuarioEntry.Text
                };
                await App.SQLiteDB.SaveUsuarioAsync(usuario);
                await DisplayAlert("Éxito", "Usuario registrado correctamente", "Ok");
                llenarDatos();
                LimpiarCampos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese todos los datos correctamente", "Ok");
            }
        }
        public async void llenarDatos ()
        {
            var UsuarioList = await App.SQLiteDB.GetUsuariosAsync();
            if (UsuarioList != null)
            {
                lstUsuario.ItemsSource = UsuarioList;
            }
        }

        public bool validaDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(nombreEntry.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(apellidoEntry.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(emailEntry.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(contraseñaEntry.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(usuarioEntry.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
        private async Task CargarUsuarios()
        {
            var usuarios = await App.SQLiteDB.GetUsuariosAsync();
            if (usuarios != null)
            {
                lstUsuario.ItemsSource = usuarios;
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarUsuarios();
        }

        private async void btnActrualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdEntry.Text))
            {
                int idUsuario = Convert.ToInt32(IdEntry.Text);
                Usuario usuario = await App.SQLiteDB.GetUsuarioByIdAsync(idUsuario);

                if (usuario != null)
                {
                    usuario.Nombre = nombreEntry.Text;
                    usuario.Apellido = apellidoEntry.Text;
                    usuario.Email = emailEntry.Text;
                    usuario.Contraseña = contraseñaEntry.Text;
                    usuario.User = usuarioEntry.Text;

                    await App.SQLiteDB.UpdateUsuarioAsync(usuario);
                    await DisplayAlert("Éxito", "Usuario actualizado correctamente", "Ok");
                    llenarDatos();
                }
                else
                {
                    await DisplayAlert("Advertencia", "El usuario seleccionado no existe", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Seleccione un usuario para actualizar", "Ok");
            }
        }
        



        private async void lstUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Usuario)e.SelectedItem;

            IdEntry.IsVisible = true;
      

            if (!string.IsNullOrEmpty(obj.Id.ToString()))
            {
                var usuario = await App.SQLiteDB.GetUsuarioByIdAsync(obj.Id);
                if (usuario != null)
                {
                    IdEntry.Text = usuario.Id.ToString();
                    nombreEntry.Text = usuario.Nombre;
                    apellidoEntry.Text = usuario.Apellido;
                    emailEntry.Text = usuario.Email;
                    contraseñaEntry.Text = usuario.Contraseña;
                    usuarioEntry.Text = usuario.User;
                }
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdEntry.Text))
            {
                int idUsuario = Convert.ToInt32(IdEntry.Text);
                Usuario usuario = await App.SQLiteDB.GetUsuarioByIdAsync(idUsuario);

                if (usuario != null)
                {
                    await App.SQLiteDB.DeleteUsuarioAnsyc(usuario);
                    await DisplayAlert("Éxito", "Usuario eliminado correctamente", "Ok");
                    llenarDatos(); 
                    LimpiarCampos();
                }
                else
                {
                    await DisplayAlert("Advertencia", "El usuario seleccionado no existe", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Seleccione un usuario para eliminar", "Ok");
            }
        }

        private void LimpiarCampos()
        {

            IdEntry.Text = string.Empty;
            nombreEntry.Text = string.Empty;
            apellidoEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;
            contraseñaEntry.Text = string.Empty;
            usuarioEntry.Text = string.Empty;
        }

    }
}
