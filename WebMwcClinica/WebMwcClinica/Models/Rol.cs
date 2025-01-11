using System;
using System.Collections.Generic;

namespace WebMwcClinica.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int RolId { get; set; }
        public string RolDescription { get; set; } = null!;
        public string RolStatus { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
