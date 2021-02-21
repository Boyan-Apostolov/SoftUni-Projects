using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;

namespace RecipesApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var db = new RecipesDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

           var recipe = new Recipe
           {
               Name = "Musaka", 
               Description = "Traditional Bulgarian/Turkish meal.",
               CookingTime = new TimeSpan(2, 3, 4)
           };

           recipe.Ingredients.Add(new RecipeIngredient
           {
               Ingredient = new Ingredient {Name = "Potato"},
               Quantity = 2000
           });

           recipe.Ingredients.Add(new RecipeIngredient
           {
               Ingredient = new Ingredient { Name = "Meat" },
               Quantity = 1000
           });

            db.Recipes.Select(x => new
           {
               Egn = EF.Property<string>(x,"EGN")

           });

           db.Recipes.Add(recipe);

           db.SaveChanges();
        }
    }
}
