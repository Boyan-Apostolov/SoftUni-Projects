using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecipesApp.Models
{
    public class RecipeConfigurations : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.Name);

                //builder.Ignore(x => x.Test);

                builder.Property<string>("EGN").HasColumnType("nvarchar(10)");
        }
    }
}
