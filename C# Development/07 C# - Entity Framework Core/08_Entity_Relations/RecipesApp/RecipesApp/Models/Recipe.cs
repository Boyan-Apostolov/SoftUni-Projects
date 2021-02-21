using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipesApp.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
        }
        [Key]
        [Range(1000,2000)]
        public int Id { get; set; }

        [Column("Title", Order = 3, TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan CookingTime { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
