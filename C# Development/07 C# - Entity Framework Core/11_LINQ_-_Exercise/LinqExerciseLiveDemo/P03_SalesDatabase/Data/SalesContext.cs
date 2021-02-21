using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SalesDb;Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();
                entity.Property(e => e.Description).HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(e => e.Name).IsUnicode();

                e.Property(e => e.Email).IsUnicode(false);

                e.Property(e => e.CreditCardNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Store>(e => { e.Property(e => e.Name).IsUnicode(); });

            modelBuilder.Entity<Sale>(e =>
            {
                e.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
