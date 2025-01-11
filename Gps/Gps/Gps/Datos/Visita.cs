using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gps.Datos
{
    public class Visita
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTienda { get; set; }
        public string NombreDueno { get; set; }
        public string HoraLlegada { get; set; }
        public string FechaVisita { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
