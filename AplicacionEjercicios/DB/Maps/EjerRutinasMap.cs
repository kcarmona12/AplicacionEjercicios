using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AplicacionEjercicios.Models;


namespace AplicacionEjercicios.DB.Maps
{
    public class EjerRutinasMap : IEntityTypeConfiguration<EjerRutinas>
    {
        public void Configure(EntityTypeBuilder<EjerRutinas> builder)
        {
            builder.ToTable("EjercicioRutina");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Rutina).WithMany(o => o.EjerRutinas).HasForeignKey(o => o.RutinaId);
            builder.HasOne(o => o.Ejercicio).WithMany(o => o.EjerciRutinas).HasForeignKey(o => o.EjercicioId);
        }

        
    }
}


