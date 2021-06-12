using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionEjercicios.Models
{
    public class Ejercicios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Link { get; set; }
        public List<EjerRutinas> EjerciRutinas { get; set; }
    }
}
