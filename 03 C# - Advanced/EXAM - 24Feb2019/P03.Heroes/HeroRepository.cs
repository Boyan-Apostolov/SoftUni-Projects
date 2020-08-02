using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public List<Hero> data { get; set; }

        public int Count => data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            data = data.Where(x => x.Name != name).Select(y => y).ToList();
        }

        // TODO: Check if this works
        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = this.data.OrderBy(h => h.Item.Strength).First();
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = this.data.OrderBy(h => h.Item.Ability).First();
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = this.data.OrderBy(h => h.Item.Intelligence).First();
            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb3 = new StringBuilder();
           
            if (this.data.Count >= 0)
            {
                foreach (var hero in this.data)
                {
                    sb3.AppendLine($"{hero}");
                }
            }
 
            return sb3.ToString().TrimEnd();
        }

    }
}
