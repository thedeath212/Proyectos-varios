using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    public class ServiceLogin : IServiceLogin
    {
        private readonly BDClinicaContext _context;
        //Inyeccion de dependencia
        public ServiceLogin(BDClinicaContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {

            try
            {
                var user = _context.Users
                    .Where(data => data.UsuStatus.Equals("A") &&
                                   data.UsuUsername.Equals(username) &&
                                   data.UsuPassword.Equals(password)) // Aquí deberías usar hash y sal para comparar contraseñas
                    .FirstOrDefault();

                if (user != null)
                {
                    if (user.UsuStatus.Equals("B"))
                    {
                        throw new InvalidOperationException("Tu usuario está bloqueado.");
                    }
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error en login", ex);
            }
        }


        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
