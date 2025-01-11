using System;
using System.Collections.Generic;

namespace WebMwcClinica.Models
{
    public partial class PersonSpecialty
    {
        public int? PerId { get; set; }
        public short? EspId { get; set; }

        public virtual Especialidad? Esp { get; set; }
        public virtual Persona? Per { get; set; }
    }
}
