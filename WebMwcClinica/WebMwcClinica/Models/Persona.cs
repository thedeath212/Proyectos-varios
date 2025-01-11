using System;
using System.Collections.Generic;

namespace WebMwcClinica.Models
{
    public partial class Persona
    {
        public int PerId { get; set; }
        public string PerNombre { get; set; } = null!;
        public string PerApellido { get; set; } = null!;
        public string PerDireccion { get; set; } = null!;
        public string PerCorreo { get; set; } = null!;
        public string PerTelefono { get; set; } = null!;
        public string PerTiposangre { get; set; } = null!;
        public string PerGenero { get; set; } = null!;
        public string PerCedula { get; set; } = null!;
        public DateTime PerFechaNacimiento { get; set; }
        public string PerEstado { get; set; } = null!;
        public DateTime PerFechaCreacion { get; set; }
        public DateTime? PerFechaModificacion { get; set; }
        public DateTime? PerFechaEliminar { get; set; }
        public byte[]? PerPhoto { get; set; } = null;
    }
}
