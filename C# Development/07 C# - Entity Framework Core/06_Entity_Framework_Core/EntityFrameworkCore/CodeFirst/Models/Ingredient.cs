using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Models
{
    class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public Recipe Recipe { get; set; }
    }
}
