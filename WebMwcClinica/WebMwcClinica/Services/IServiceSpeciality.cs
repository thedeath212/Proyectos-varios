using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    //Contrato metodos a trabajar

    public interface IServiceSpeciality
    {
        IEnumerable<Especialidad> getAll();
        Especialidad getById(short id);

        Especialidad getByName(string name);

        bool save(Especialidad especialidad);

        bool update(Especialidad especialidad);

        bool deleteById(int id);
    }
}

