using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionEjercicios.DB;
using AplicacionEjercicios.ESTRATEGIA;
using AplicacionEjercicios.Models;


namespace AplicacionEjercicios.Controllers
{
    public class RutinaController1 : Controller
    {
        private readonly AppRutinasContext context;
        public RutinaController1()
        {
            context = new AppRutinasContext();
        }

        public IActionResult Index()
        {


            var usuarioId = HttpContext.Session.GetString("UsuarioId");
            if (!string.IsNullOrEmpty(usuarioId))
            {
                var rutinas = context.Rutinas.Include(o => o.EjerRutinas)
                                             .ThenInclude(o => o.Ejercicio)
                                             .Where(x => x.UsuarioId.ToString() == usuarioId)
                                             .ToList();
                return View(rutinas);
            }
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Rutina rutina)
        {
            if (!string.IsNullOrEmpty(rutina.Nombre))
            {
                var usuarioId = HttpContext.Session.GetString("UsuarioId");
                rutina.UsuarioId = int.Parse(usuarioId);
                context.Rutinas.Add(rutina);
                context.SaveChanges();
                var registradorEjercicios = new RegistraEjercicio(rutina);
                registradorEjercicios.registraEjercicio();
                return RedirectToAction("Index", "Rutina");
            }
            ModelState.AddModelError("Error", "Los datos ingresados no válidos");
            return View();
        }
        public IActionResult Detalle(int id)
        {
            var rutina = context.Rutinas.Include(o => o.EjerRutinas)
                                        .ThenInclude(o => o.Ejercicio)
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();

            return View(rutina);
        }
    }
}

