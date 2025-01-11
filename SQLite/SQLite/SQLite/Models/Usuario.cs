using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SQLite.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(6)]
        public string Contraseña { get; set; }
        [MaxLength(50)] 
        public string User { get; set; }
    }
}
