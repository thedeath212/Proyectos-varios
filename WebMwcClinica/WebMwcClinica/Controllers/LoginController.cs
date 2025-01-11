using Microsoft.AspNetCore.Mvc;
using WebMwcClinica.Services;

namespace WebMvClinica.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServiceLogin _serviceLogin;

        public LoginController(IServiceLogin serviceLogin)
        {
            _serviceLogin = serviceLogin;
        }
        //Get
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _serviceLogin.Authenticate(username, password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.UsuId.ToString());  
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Credenciales incorrectas.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
          
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
       
    }
}
