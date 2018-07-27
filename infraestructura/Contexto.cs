using System;
using infraestructura.entidades;
using Microsoft.EntityFrameworkCore;

namespace infraestructura
{
    public class Contexto : DbContext
    {
        private readonly string _connectionString;
        
        public Contexto(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(_connectionString);
        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
    }
}
