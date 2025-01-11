using Microsoft.EntityFrameworkCore;
using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    public class ServicePerson : IServicePerson
    {
        private readonly BDClinicaContext _context;
        //Inyeccion de dependencia
        public ServicePerson(BDClinicaContext context)
        {
            _context = context;
        }


        public IEnumerable<Persona> getAll()
        {
            try
            {
                var result = _context.Personas.Where(data => data.PerEstado
                .Equals("A")).ToList();

                if (result.Count == 0)
                {
                    return null;
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public Persona getById(int id)
        {
            try
            {
                var result = _context.Personas.Where(data => data.PerId.Equals(id)).FirstOrDefault();

                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public Persona getByName(string Nombre)
        {
            try
            {
                var result = _context.Personas.FirstOrDefault(p => p.PerNombre == Nombre);
                return result;
            }
            catch
            {
                return null;
            }
        }


        public bool save(Persona persona)
        {
            try
            {
                var existingPersona = getByName(persona.PerNombre);

                if (existingPersona != null)
                {
                    return false;
                }

                persona.PerFechaCreacion = DateTime.Now;
                persona.PerEstado = "A";

                _context.Personas.Add(persona);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar guardar la persona: {ex.Message}");
                return false;
            }
        }

        public bool update(Persona persona)
        {
            try
            {
                var existingEntity = _context.Personas.Find(persona.PerId);

                if (existingEntity == null)
                {
                    return false;
                }

                existingEntity.PerNombre = persona.PerNombre;
                existingEntity.PerApellido = persona.PerApellido;
                existingEntity.PerDireccion = persona.PerDireccion;
                existingEntity.PerCorreo = persona.PerCorreo;
                existingEntity.PerTelefono = persona.PerTelefono;
                existingEntity.PerTiposangre = persona.PerTiposangre;
                existingEntity.PerGenero = persona.PerGenero;
                existingEntity.PerCedula = persona.PerCedula;
                existingEntity.PerFechaNacimiento = persona.PerFechaNacimiento;
                existingEntity.PerFechaModificacion = DateTime.Now;

                if (persona.PerPhoto != null)
                {
                    existingEntity.PerPhoto = persona.PerPhoto; // Actualiza la foto si se proporciona una nueva
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar actualizar la persona: {ex.Message}");
                return false;
            }
        }

        public bool deleteById(int id)
        {
            try
            {
                var existingPersona = getById(Convert.ToInt16(id));

                if (existingPersona == null)
                {
                    return false;
                }
                existingPersona.PerFechaEliminar = DateTime.Now;
                existingPersona.PerEstado = "I";
                _context.Entry(existingPersona).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

       
    }
}
