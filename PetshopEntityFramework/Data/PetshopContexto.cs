using Microsoft.EntityFrameworkCore;
using PetshopEntityFramework.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetshopEntityFramework.Data
{
    internal class PetshopContexto : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<ConsultaMedica> ConsultasMedicas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=CE-LAB6313;Initial Catalog=PetshopSpinola;User ID=sa;Password=123456;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
