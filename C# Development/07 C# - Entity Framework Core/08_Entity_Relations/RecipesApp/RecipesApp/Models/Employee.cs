using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public Town? BirthTown { get; set; }

        public Town? WorkTown { get; set; }
    }
}
