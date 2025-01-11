using System;
using System.Collections.Generic;

namespace WebMwcClinica.Models
{
    public partial class User
    {
        public int UsuId { get; set; }
        public string UsuUsername { get; set; } = null!;
        public string UsuPassword { get; set; } = null!;
        public string UsuName { get; set; } = null!;
        public string UsuLastname { get; set; } = null!;
        public string UsuStatus { get; set; } = null!;
        public DateTime? UsuAdd { get; set; }
        public DateTime? UsuUpdate { get; set; }
        public DateTime? UsuDelete { get; set; }
        public int RolId { get; set; }
        public string? UsuEmail { get; set; }
        public decimal? UsuSueldo { get; set; }
        public int? UsuIntentos { get; set; }

        public virtual Rol Rol { get; set; } = null!;
    }
}
