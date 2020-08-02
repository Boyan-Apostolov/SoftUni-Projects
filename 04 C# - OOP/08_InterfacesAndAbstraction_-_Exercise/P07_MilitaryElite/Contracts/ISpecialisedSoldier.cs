using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Enumberations;

namespace P07_MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
