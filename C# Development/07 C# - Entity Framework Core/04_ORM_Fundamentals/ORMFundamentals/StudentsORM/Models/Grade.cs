using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace StudentsORM.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
