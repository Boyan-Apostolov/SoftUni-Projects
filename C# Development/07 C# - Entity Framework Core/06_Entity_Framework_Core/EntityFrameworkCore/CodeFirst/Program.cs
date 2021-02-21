using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //var db = new RecipesDbContext();
            //db.Database.EnsureCreated();

            // db.Recipes.Add(new Recipe
            // {
            //     Name = "Musaka",
            //     Ingredients = new List<Ingredient>()

            // });

            // var recipes = db.Recipes.OrderBy(x => x.Name).ToList();

            // var recipie = db.Recipes.First();
            // //db.Recipes.Remove(recipie);

            // //Console.WriteLine(recipie+ "With Ingredients: "+ String.Join(", ",recipie.Ingredients.ToList()));

            //foreach (var recipe in recipes)
            //{
            //    Console.WriteLine(recipe.Name);
            //}

            //db.SaveChanges();

            var db = new RecipesDbContext();
            db.Database.EnsureCreated();

        }
    }
}
