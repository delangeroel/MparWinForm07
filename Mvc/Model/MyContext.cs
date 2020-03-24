using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MparWinForm07.Mvc.Model;
using static MparWinForm07.Mvc.Model.ActionCode;

namespace MparWinForm07.Mvc.Model
{
    public class MyContext : DbContext
    {
        public DbSet<ActionCode> Actioncode { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Blog> Blog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=MparWinForm07;trusted_connection=true;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ActionCode>()
                .HasIndex(p => new { p.Actioncode, p.Description })
                .IsUnique()
                .HasName("Index_ActionCode");
            // Create an index

            modelBuilder
                .Entity<ActionCode>()
               .Property(e => e.Kleur)
               .HasConversion(
               v => v.ToString(),
               v => (Kleuren)Enum.Parse(typeof(Kleuren), v));//https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions

        }
    }

}
