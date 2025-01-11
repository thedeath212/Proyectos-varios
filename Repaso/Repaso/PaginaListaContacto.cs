using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Repaso
{
    public partial class PaginaListaContacto : MasterDetailPage
    {
        public PaginaListaContacto()
        {
            var lista = new ListView();
            var contactos = Logica.crearContactoa();

            var nombresUnicos = contactos
                .OrderBy(c => c.id)
                .Select(c => $"{c.id}: {c.Nombre}")
                .Distinct()
                .ToList();

            lista.ItemsSource = nombresUnicos;
            lista.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var seleccion = (string)e.SelectedItem;
                    var idSeleccionado = int.Parse(seleccion.Split(':')[0].Trim());

                    var contactoSeleccionado = contactos.FirstOrDefault(c => c.id == idSeleccionado);

                    if (contactoSeleccionado != null)
                    {
                        Detail = new NavigationPage(new PageContacto(contactoSeleccionado, contactos));
                    }

                    IsPresented = false;
                }
            };

            Master = new ContentPage
            {
                Title = "Contacto",
                Content = lista
            };

            Detail = new NavigationPage(new PageContacto(contactos.OrderBy(c => c.id).First(), contactos));
        }
    }
}
