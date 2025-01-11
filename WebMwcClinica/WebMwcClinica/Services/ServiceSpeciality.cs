using Microsoft.EntityFrameworkCore;
using WebMwcClinica.Models;

namespace WebMwcClinica.Services
{
    public class ServiceSpeciality : IServiceSpeciality
    {
        private readonly BDClinicaContext _context;
        //Inyeccion de dependencia
        public ServiceSpeciality(BDClinicaContext context)
        {
            _context = context;
        }
        public IEnumerable<Especialidad> getAll()
        {
            try
            {
                var result = _context.Especialidads.Where(data => data.EspEstado
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

        public Especialidad getById(short id)
        {
            try
            {
                var result = _context.Especialidads.Where(data => data.EspId.Equals(id)).FirstOrDefault();

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

        public Especialidad getByName(string name)
        {
            try
            {
                var result = _context.Especialidads
                    .FirstOrDefault(data => data.EspEstado.Equals("A") &&
                                              data.EspDescripcion.Equals(name, StringComparison.OrdinalIgnoreCase));

                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error en getByName: {ex.Message}");
                return null;
            }
        }

        public bool update(Especialidad especialidad)
        {
            try
            {
                var existingEntity = _context.Especialidads.Find(especialidad.EspId);

                if (existingEntity == null)
                {
                   
                    return false;
                }

                existingEntity.EspDescripcion = especialidad.EspDescripcion;
                existingEntity.EspObservacion = especialidad.EspObservacion;
                existingEntity.EspImag = especialidad.EspImag;
                existingEntity.EspUpdate = DateTime.Now;


                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                
                return false;
            }
            catch (Exception)
            {
               
                return false;
            }
        }


        public bool deleteById(int id)
        {
            try
            {
                var especialidadExist = getById(Convert.ToInt16(id));

                if (especialidadExist == null)
                {
                    return false;
                }
                especialidadExist.EspDelete = DateTime.Now;
                especialidadExist.EspEstado = "I";
                _context.Entry(especialidadExist).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool save(Especialidad especialidad)
        {
            try
            {
                var especialidadExist = getByName(especialidad.EspDescripcion);

                if (especialidadExist != null)
                {
                    return false;
                }

                especialidad.EspAdd = DateTime.Now;
                especialidad.EspEstado = "A";

                _context.Add(especialidad);

                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}