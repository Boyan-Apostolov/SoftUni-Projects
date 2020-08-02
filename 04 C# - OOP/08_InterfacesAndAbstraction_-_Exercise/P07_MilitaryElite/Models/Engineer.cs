using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;

namespace P07_MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>) this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Repairs");
            foreach (var reapait in this.repairs)
            {
                sb.AppendLine(reapait.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
