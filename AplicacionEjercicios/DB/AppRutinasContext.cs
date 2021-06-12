using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionEjercicios.DB.Maps;
using AplicacionEjercicios.Models;
using Microsoft.EntityFrameworkCore;


namespace AplicacionEjercicios.DB
{
    public class AppRutinasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<EjerRutinas> EjercicioRutinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AplicacionEjercicios;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EjerciciosMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new EjerRutinasMap());
        }
    }
}