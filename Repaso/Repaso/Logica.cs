using Repaso;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

public class Logica
{
    public static event EventHandler ListasCambiadas;

    public static ObservableCollection<String> listaNombres = new ObservableCollection<String>()
    {
        "Dominic ","Jose","Fercho","Juan"
    };

    public static ObservableCollection<String> listaapellidos = new ObservableCollection<String>()
    {
        "Muñoz ","Villalba","Cruz","Simbaña"
    };

    public static ObservableCollection<String> listacalles = new ObservableCollection<String>()
    {
        "Solanda","Villaflora","La prensa","la Kenedy"
    };

    public static ObservableCollection<int> ListaIds = new ObservableCollection<int>()
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12, 13, 14,15,16,17,18,19,20
    };

    public static ObservableCollection<Contacto> contactos = crearContactoa();

    public static ObservableCollection<Contacto> crearContactoa()
    {
        var random = new Random();
        var contactos = new ObservableCollection<Contacto>();
        var idsDisponibles = new List<int>(ListaIds);

        foreach (var nombre in listaNombres)
        {
            foreach (var apellido in listaapellidos)
            {
                if (idsDisponibles.Count > 0)
                {
                    var index = random.Next(idsDisponibles.Count);
                    var id = idsDisponibles[index];
                    idsDisponibles.RemoveAt(index);

                    var calle = listacalles[random.Next(listacalles.Count)];
                    var contacto = new Contacto()
                    {
                        id = id,
                        Nombre = nombre + " " + apellido,
                        Direccion = "Av: " + calle + "   Nro : " + random.Next(100),
                        Telefono = generarTelefono()
                    };
                    contactos.Add(contacto);
                }
                else
                {
                    break;
                }
            }
        }

        return contactos;
    }

    private static string generarTelefono()
    {
        var random = new Random();
        StringBuilder telefono = new StringBuilder();
        telefono.Append("(");
        telefono.Append(random.Next(100, 999));
        telefono.Append(")");
        telefono.Append(random.Next(1000000, 9999999));
        return telefono.ToString();
    }

    public static void AgregarContacto(string nombre, string apellido, string calle)
    {
        int nuevoId = ListaIds.Any() ? ListaIds.Max() + 1 : 1;

        listaNombres.Add(nombre);
        listaapellidos.Add(apellido);
        listacalles.Add(calle);
        ListaIds.Add(nuevoId);

        var nuevoContacto = new Contacto()
        {
            id = nuevoId,
            Nombre = nombre + " " + apellido,
            Direccion = "Av: " + calle + "   Nro : " + new Random().Next(100),
            Telefono = generarTelefono()
        };
        contactos.Add(nuevoContacto);

        OnListasCambiadas();
    }


    public static void EliminarContactoPorId(int idAEliminar)
    {
        int indiceAEliminar = ListaIds.IndexOf(idAEliminar);

        if (indiceAEliminar != -1)
        {
            listaNombres.RemoveAt(indiceAEliminar);
            listaapellidos.RemoveAt(indiceAEliminar);
            listacalles.RemoveAt(indiceAEliminar);
            ListaIds.RemoveAt(indiceAEliminar);
            contactos.RemoveAt(indiceAEliminar);

            OnListasCambiadas();
        }
    }

    public static void OnListasCambiadas()
    {
        ListasCambiadas?.Invoke(null, EventArgs.Empty);
    }
}