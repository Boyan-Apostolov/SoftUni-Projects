using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RecipesApp.Models
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {
            
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Recipes;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfigurations());
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Ingredients)
                .WithOne(x => x.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeIngredient>().HasKey(x => new {x.IngredientId, x.RecipeId});

            //modelBuilder.Entity<Recipe>()
            //    .HasMany(x => x.Ingredients)
            //    .WithOne(x => x.Recipe);

            //modelBuilder.Entity<Ingredient>()
            //    .HasMany(x => x.Recipes)
            //    .WithOne(x => x.Ingredient);
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Town> Towns { get; set; }

    }
}
