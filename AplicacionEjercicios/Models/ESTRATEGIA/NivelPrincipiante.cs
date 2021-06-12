using AplicacionEjercicios.DB.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using AplicacionEjercicios.DB;
using System.Threading.Tasks;
using AplicacionEjercicios.Models;


namespace AplicacionEjercicios.ESTRATEGIA
{
    public class NivelPrincipiante : RegistraRutina
    {
        private readonly AppRutinasContext context;

        public NivelPrincipiante()
        {
            context = new AppRutinasContext();
        }


        public void RegistrarEjercicios(Rutina rutina)
        {
            var ejercicios = context.Ejercicios.ToList();
            var rand = new Random();
            for (var i = 0; i < 5; i++)
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
   