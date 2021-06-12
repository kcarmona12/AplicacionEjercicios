using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AplicacionEjercicios.Models;

namespace AplicacionEjercicios.DB.Maps
{
    public class RutinaMap : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutina");
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.EjerRutinas).WithOne(o => o.Rutina).HasForeignKey(o => o.RutinaId);
        }
    }
}
