using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.Enumberations;
using P07_MilitaryElite.EXCEPTIONS;

namespace P07_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = this.tryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps tryParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);
            if (!parsed)
            {
                throw new ArgumentException("Invalid corps!");
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}
