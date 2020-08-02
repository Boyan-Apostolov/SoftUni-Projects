using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;

namespace P07_MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) this.missions;
        public void AddMIssion(IMission mission)
        {
            this.missions.Add(mission);
        }

       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Missions:");
            foreach (var reapait in this.missions)
            {
                sb.AppendLine(reapait.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    
    }
}
