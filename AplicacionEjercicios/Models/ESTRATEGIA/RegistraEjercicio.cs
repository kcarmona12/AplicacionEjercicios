using AplicacionEjercicios.Models;
using System;

namespace AplicacionEjercicios.ESTRATEGIA
{
    public class RegistraEjercicio
    {
        private Rutina rutina;

        public RegistraEjercicio(Rutina rutina)
        {
            this.rutina = rutina;
        }

        public class RegistradorDeEjercicios
        {
            private RegistraRutina registrador;
            private Rutina rutina;

            public RegistradorDeEjercicios(Rutina rutina)
            {
                this.rutina = rutina;
                if (rutina.Tipo == TipoRutina.AVANZADO)
                {
                    registrador = new NivelAvanzado();
                }
                else if (rutina.Tipo == TipoRutina.INTERMEDIO)
                {
                    registrador = new NivelIntermedio();
                }
                else
                {
                    registrador = new NivelPrincipiante();
                }
            }

            public void RegistrarEjercicios()
            {
                registrador.RegistrarEjercicios(rutina);
            }
        }

        internal void registraEjercicio()
        {
            throw new NotImplementedException();
        }
    }
}
    