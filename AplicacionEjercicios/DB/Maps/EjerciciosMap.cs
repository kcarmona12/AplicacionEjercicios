using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AplicacionEjercicios.Models;

namespace AplicacionEjercicios.DB.Maps
{
    public class EjerciciosMap : IEntityTypeConfiguration<Ejercicios>
    {

        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Ejercicio");
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.EjerciRutinas).WithOne(o => o.Ejercicio).HasForeignKey(o => o.EjercicioId);
        }
    }
}
