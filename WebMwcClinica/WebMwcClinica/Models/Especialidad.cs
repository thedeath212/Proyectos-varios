using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMwcClinica.Models
{
    public partial class Especialidad
    {
        [DisplayName("Id")]
        public short EspId { get; set; }
        [DisplayName("Nombre")]
        [StringLength(100)]
        public string EspDescripcion { get; set; } = null!;
        [DisplayName("Estado")]
        [StringLength(1)]
        public string EspEstado { get; set; } = null!;
        [DisplayName("Fecha AGR")]
        public DateTime? EspAdd { get; set; }
        [DisplayName("Fecha Update")]
        public DateTime? EspUpdate { get; set; }
        [DisplayName("Fecha Delete")]
        public DateTime? EspDelete { get; set; }
        public string? EspObservacion { get; set; }
        public byte[]? EspImag { get; set; } = null;
    }
}
