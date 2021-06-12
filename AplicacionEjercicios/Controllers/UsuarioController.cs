using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicacionEjercicios.DB;
using AplicacionEjercicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionEjercicios.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppRutinasContext context;
        public UsuarioController() => context = new AppRutinasContext();

        public IActionResult Index() => View();


        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Username) && !string.IsNullOrEmpty(usuario.Password))
            {
                context.Usuarios.Add(usuario);

                context.SaveChanges();

                return RedirectToAction("Login", "Auth");
            }

            ModelState.AddModelError("Error", "Los datos ingresados no válidos");

            return View();
        }
    }
}
