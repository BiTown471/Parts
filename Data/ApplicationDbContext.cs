using Microsoft.EntityFrameworkCore;
using Parts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }

        public DbSet<Klienci> Klienci { get; set; }
        public DbSet<Pozycja> Pozycja { get; set; }
        public DbSet<Pracownicy> Pracownicy { get; set; }
        public DbSet<Produkty> Produkty { get; set; }
        public DbSet<Zamowienia> Zamowienia { get; set; }
    }
}
