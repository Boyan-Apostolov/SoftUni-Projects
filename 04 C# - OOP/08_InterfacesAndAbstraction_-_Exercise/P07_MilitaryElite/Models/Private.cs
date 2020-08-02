using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;

namespace P07_MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }
        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary}";
        }
    }
}
