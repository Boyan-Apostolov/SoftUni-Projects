using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RecipesApp.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("WorkTown")]
        public ICollection<Employee> Workers { get; set; }

        [InverseProperty("BirthTown")]
        public ICollection<Employee> Citizens { get; set; }
    }
}
