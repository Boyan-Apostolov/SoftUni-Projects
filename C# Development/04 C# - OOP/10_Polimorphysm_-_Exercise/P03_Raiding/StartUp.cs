using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ICollection<BaseHero> heroes = new List<BaseHero>();

            Warrior warrior = null;
            Druid druid = null;
            Paladin paladin = null;
            Rogue rogue = null;

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    druid = new Druid(name);
                    heroes.Add(druid);
                }
                else if (heroType == "Paladin")
                {
                    paladin = new Paladin(name);
                    heroes.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    rogue = new Rogue(name);
                    heroes.Add(rogue);
                }
                else if (heroType == "Warrior")
                {
                    warrior = new Warrior(name);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());

            int totalPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
