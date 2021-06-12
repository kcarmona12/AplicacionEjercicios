using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicacionEjercicios.DB;
using AplicacionEjercicios.Models;

namespace AplicacionEjercicios.Controllers
{
    public class LoginController : Controller
    { 

       private readonly AppRutinasContext context;
        public LoginController () => context = new AppRutinasContext();

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Username))
            {
                var usuarioEncontrado = context.Usuarios.Where(o => o.Username == usuario.Username && o.Password == usuario.Password).FirstOrDefault();
                if (usuarioEncontrado != null)
                {
                    HttpContext.Session.SetString("UsuarioId", usuarioEncontrado.Id.ToString());
                    return RedirectToAction("Index", "Rutina");
                }
            }
            ViewBag.LoginError = "Credencial inválidas";
            return View();
        }
    }
}



        
