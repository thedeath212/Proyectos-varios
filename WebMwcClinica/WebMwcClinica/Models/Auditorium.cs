using System;
using System.Collections.Generic;

namespace WebMwcClinica.Models
{
    public partial class Auditorium
    {
        public int AudiId { get; set; }
        public DateTime AudiFecha { get; set; }
        public string AudiUsuario { get; set; } = null!;
        public string AudiTipo { get; set; } = null!;
        public int AudiCodigoRegistro { get; set; }
        public string AudiEstado { get; set; } = null!;
    }
}
