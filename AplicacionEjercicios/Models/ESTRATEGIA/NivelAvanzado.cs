using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionEjercicios.DB;
using AplicacionEjercicios.ESTRATEGIA;
using AplicacionEjercicios.Models;


namespace AplicacionEjercicios.ESTRATEGIA
{
    public class NivelAvanzado : RegistraRutina

    {
        private readonly AppRutinasContext context;

        public NivelAvanzado() => context = new AppRutinasContext();


        public void RegistrarEjercicios(Rutina rutina)
        {
            var ejercicios = context.Ejercicios.ToList();
            var rand = new Random();
            for (var i = 0; i < 15; i++)
            {
                var ejercicioRutina = new EjerRutinas();
                ejercicioRutina.RutinaId = rutina.Id;
                var index = rand.Next(ejercicios.Count);
                ejercicioRutina.EjercicioId = ejercicios[index].Id;
                ejercicioRutina.Duracion = 120;
                context.EjercicioRutinas.Add(ejercicioRutina);
                context.SaveChanges();

            }
        }
    }
}


        