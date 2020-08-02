using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Contracts
{
    public interface ISoldier
    {
        int Id { get; set; }
        string FirstName { get; }
        string LastName { get; }
    }
}
