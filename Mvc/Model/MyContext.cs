using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MparWinForm07.Mvc.Model;

namespace MparWinForm07.Mvc.Model
{
    public class MyContext : DbContext
    {
        public DbSet<ActionCode> Actioncode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=MparWinForm07;trusted_connection=true;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionCode>()
                .HasIndex(p => new { p.Actioncode, p.Description })
                .IsUnique()
                .HasName("Index_ActionCode");
                // Create an index
        }
    }

}
