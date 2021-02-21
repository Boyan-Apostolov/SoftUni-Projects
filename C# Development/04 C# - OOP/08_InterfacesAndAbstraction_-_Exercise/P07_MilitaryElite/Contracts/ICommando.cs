using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMIssion(IMission mission);
    }
}
