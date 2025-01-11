using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    public interface IServicePerson
    {
        IEnumerable<Persona> getAll();
        Persona getById(int id);

        Persona getByName(string Nombre);
        bool save(Persona persona);
        bool update(Persona persona);
        bool deleteById(int id);
    }
}
