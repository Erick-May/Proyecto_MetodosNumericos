using Microsoft.EntityFrameworkCore;
using Proyecto_MetodosNumericos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MetodosNumericos.Data
{
    public class AppMetodosContext : DbContext
    {
        public AppMetodosContext()
        {
            // Esto le dice a EF Core que si la base de datos o las tablas no existen, las cree.
            this.Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistorialOperacion> HistorialOperaciones { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=AppMetodosDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}
