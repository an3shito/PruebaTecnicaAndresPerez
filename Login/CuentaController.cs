using Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: Cuenta/Login, se crea un metodo post para enviar la informcaión si la autenticación se realiza con exito.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes agregar la lógica de autenticación
                TempData["Message"] = "Proceso realizado con Éxito!";
                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
