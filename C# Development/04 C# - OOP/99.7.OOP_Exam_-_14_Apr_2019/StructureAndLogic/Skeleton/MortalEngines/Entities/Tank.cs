using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine
    {
        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, 100)
        {
            this.DefenseMode = true;
        }


        public bool DefenseMode { get; set; }

        public void ToggleDefenceMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -=40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            if (this.DefenseMode == true)
            {
                return base.ToString() + Environment.NewLine + $" *Defense: ON";

            }
            return base.ToString() + Environment.NewLine + $" *Defense: OFF";
        }
    }
}
