using Microsoft.EntityFrameworkCore;
using SistemaPizzaria.Dominio.Entidades;
using System;
using System.IO;

namespace SistemaPizzaria.Infraestrutura.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pizzaria.db");
            Console.WriteLine($"Banco de dados em: {path}");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasIndex(p => p.Nome)
                .IsUnique();
        }
    }
}
