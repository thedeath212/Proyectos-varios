using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMwcClinica.Models;
using WebMwcClinica.Services;

namespace WebMwcClinica.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly IServiceSpeciality _serviceSpeciality;

        public SpecialityController(IServiceSpeciality serviceSpeciality)
        {
            _serviceSpeciality = serviceSpeciality;
        }
        //Get
        public IActionResult Index()
        {
            var res = _serviceSpeciality.getAll();
            return View(res);
        }
        //Get
        public IActionResult Details(short? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            
            var speciality = _serviceSpeciality.getById(Convert.ToInt16(id));
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Catalogo()
        {
            var res = _serviceSpeciality.getAll();
            return View(res);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialidad especialidad, IFormFile file)

        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    long legth = file.Length;
                    if (legth < 0)
                    {
                        return BadRequest();
                    }
                    using var fileStream = file.OpenReadStream();
                    byte[] bytes = new byte[legth];
                    fileStream.Read(bytes, 0, (int)file.Length);

                    especialidad.EspImag = bytes;
                }
            }
            var resultSave = _serviceSpeciality.save(especialidad);

            if(resultSave)
            {
                return RedirectToAction("Catalogo" +
                    "");
            }
            return View(especialidad);
        }
        // GET
        public IActionResult Edit(short id)
        {


            Especialidad especialidad = _serviceSpeciality.getById(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(short id, Especialidad especialidad, IFormFile file)
        {
            if (id != especialidad.EspId)
            {
                return NotFound();
            }

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    especialidad.EspImag = memoryStream.ToArray();
                }
            }

            var resultUpdate = _serviceSpeciality.update(especialidad);

            if (resultUpdate)
            {
                especialidad = _serviceSpeciality.getById(id); // Suponiendo que haya un método para obtener la entidad por su id

                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET
        public IActionResult Delete(short id)
        {
            var especialidad = _serviceSpeciality.getById(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(short id)
        {
            var resultDelete = _serviceSpeciality.deleteById(id);

            if (resultDelete)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
