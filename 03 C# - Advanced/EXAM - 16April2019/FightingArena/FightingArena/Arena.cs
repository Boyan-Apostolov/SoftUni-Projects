using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        public Arena(string name)
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }
        public List<Gladiator> gladiators { get; set; }
        public string Name { get; set; }
        public int Count => gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].Name == name)
                {
                    gladiators.RemoveAt(i);
                    //Count = Gladiators.Count; - грешно
                }
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetStatPower()).First();
            return gladiator;

        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetWeaponPower()).First();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiator = this.gladiators.OrderByDescending(x => x.GetTotalPower()).First();
            return gladiator;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Count} gladiators are participating.";
        }
    }
}
