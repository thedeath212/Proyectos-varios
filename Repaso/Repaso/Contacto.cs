using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Repaso
{
    public class Contacto : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (direccion != value)
                {
                    direccion = value;
                    OnPropertyChanged();
                }
            }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (telefono != value)
                {
                    telefono = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Id}: {Nombre}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Contacto c = (Contacto)obj;
            return (id == c.id) && (nombre == c.nombre) && (direccion == c.direccion) && (telefono == c.telefono);
        }

        // GetHashCode override
        public override int GetHashCode()
        {
            return id.GetHashCode() ^ nombre.GetHashCode() ^ direccion.GetHashCode() ^ telefono.GetHashCode();
        }
    }
}

