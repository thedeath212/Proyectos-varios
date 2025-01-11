using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gps.Datos
{
    public class AuthService
    {
        public static async Task<bool> ValidateCredentials(string username, string password)
        {
            if (username == "usuario" && password == "contraseña")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
