using Microsoft.AspNetCore.Mvc;
using WebMwcClinica.Models;
using WebMwcClinica.Services;

namespace WebMwcClinica.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IServicePerson _servicePerson;


        public PersonaController(IServicePerson servicePerson)
        {
            _servicePerson = servicePerson;
        }
        public IActionResult Index()
        {
            var res = _servicePerson.getAll();
            return View(res);
        }
        //Get
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var persona = _servicePerson.getById(Convert.ToInt16(id));
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Persona persona, IFormFile file)
        {
            if (file!= null)
            {
                if(file.Length > 0)
                {
                    long legth = file.Length;
                    if(legth<0)
                    {
                        return BadRequest();
                    }
                    using var fileStream = file.OpenReadStream();
                    //convierte la imagen a binario
                    byte[] bytes = new byte[legth];
                    fileStream.Read(bytes, 0, (int)file.Length);

                    persona.PerPhoto = bytes;
                }
            }
            if (ModelState.IsValid)
            {
                bool resultSave = _servicePerson.save(persona);

                if (resultSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(persona);
        }

        // GET: Persona/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = _servicePerson.getById(id.Value);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.PerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool resultUpdate = _servicePerson.update(persona);

                if (resultUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(persona);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var persona = _servicePerson.getById(id);

            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var resultDelete = _servicePerson.deleteById(id);

            if (resultDelete)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}