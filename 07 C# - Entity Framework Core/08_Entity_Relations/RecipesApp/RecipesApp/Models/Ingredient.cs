using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApp.Models
{
    [Table("Ingredients",Schema =  "system")]
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<RecipeIngredient>();
        }
        public int Id { get; set; }

        [Column("Title", Order = 3, TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipes { get; set; }

    }
}
