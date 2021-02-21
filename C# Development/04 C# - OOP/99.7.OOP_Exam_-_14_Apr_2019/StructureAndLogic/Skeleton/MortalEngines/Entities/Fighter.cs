using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine 
    {
        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, 200)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            if (this.AggressiveMode == true) 
            {
                            return base.ToString() + Environment.NewLine + $" *Aggressive: ON";

            }
            return base.ToString() + Environment.NewLine + $" *Aggressive: OFF";
        }
    }
}
