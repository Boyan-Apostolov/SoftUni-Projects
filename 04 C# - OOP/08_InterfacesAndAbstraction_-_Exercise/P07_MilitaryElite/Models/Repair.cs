using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;

namespace P07_MilitaryElite.Models
{
    public class Repair : IRepair
    {

        public Repair(string partname,int hours)
        {
            this.PartName = partname;
            this.HoursWorked = hours;
        }
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Woked: {this.HoursWorked}";
        }
    }
}
