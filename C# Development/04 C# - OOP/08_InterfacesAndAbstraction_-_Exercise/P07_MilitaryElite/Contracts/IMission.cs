using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Enumberations;

namespace P07_MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
