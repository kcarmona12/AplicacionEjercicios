using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionEjercicios.Models
{
    public class EjerRutinas
    {
        public int Id { get; set; }
        public int RutinaId { get; set; }
        public int EjercicioId { get; set; }
        public int Duracion { get; set; }
        public Rutina Rutina { get; set; }
        public Ejercicios Ejercicio { get; set; }




    }
}
