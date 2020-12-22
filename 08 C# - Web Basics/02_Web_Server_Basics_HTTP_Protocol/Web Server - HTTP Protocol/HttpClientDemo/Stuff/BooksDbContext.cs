using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HttpClientDemo.Stuff
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
            
        }
        public BooksDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BooksHTTP;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
