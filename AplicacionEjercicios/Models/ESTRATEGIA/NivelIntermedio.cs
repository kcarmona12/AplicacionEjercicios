using System;
using System.Linq;
using AplicacionEjercicios.Models;
using AplicacionEjercicios.DB;

namespace AplicacionEjercicios.ESTRATEGIA
{
    public class NivelIntermedio : RegistraRutina
    {
        private readonly AppRutinasContext context;

        public NivelIntermedio()
        {
            context = new AppRutinasContext();
        }

        public void RegistrarEjercicios(Rutina rutina)
        {
            var ejercicios = context.Ejercicios.ToList();
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var ejercicioRutina = new EjerRutinas();
                ejercicioRutina.RutinaId = rutina.Id;
                var index = rand.Next(ejercicios.Count);
                ejercicioRutina.EjercicioId = ejercicios[index].Id;
                ejercicioRutina.Duracion = rand.Next(60, 121);
                context.EjercicioRutinas.Add(ejercicioRutina);
                context.SaveChanges();
            }
        }
    }
}



        