

using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    public interface IServiceLogin
    {
        User Authenticate(string username, string password);
        void Logout();

    }
}
 