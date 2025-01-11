using System;
using SQLite;

namespace Gps.Datos
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }


     
    }
}
