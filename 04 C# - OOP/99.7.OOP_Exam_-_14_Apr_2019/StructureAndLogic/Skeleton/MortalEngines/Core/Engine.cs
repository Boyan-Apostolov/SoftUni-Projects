using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Quit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "HirePilot")
                    {
                        string pilotName = input[1];

                        result = machinesManager.HirePilot(pilotName);
                    }
                    else if (input[0] == "PilotReport")
                    {
                        string pilotName = input[1];

                        result = machinesManager.PilotReport(pilotName);
                    }
                    else if (input[0] == "ManufactureTank")
                    {
                        string name = input[1];
                        double attack = double.Parse(input[2]);
                        double defense = double.Parse(input[3]);

                        result = machinesManager.ManufactureTank(name, attack, defense);
                    }
                    else if (input[0] == "ManufactureFighter")
                    {
                        string name = input[1];
                        double attack = double.Parse(input[2]);
                        double defense = double.Parse(input[2]);

                        result = machinesManager.ManufactureFighter(name, attack, defense);
                    }
                    else if (input[0] == "Report")
                    {
                        string name = input[1];
                        result = machinesManager.MachineReport(name);
                    }
                    else if (input[0] == "AggressiveMode")
                    {
                        string name = input[1];
                        result = this.machinesManager.ToggleFighterAggressiveMode(name);
                    }
                    else if (input[0] == "DefenseMode")
                    {
                        string name = input[1];
                        result = this.machinesManager.ToggleTankDefenseMode(name);
                    }
                    else if (input[0] == "Engage")
                    {
                        string pilotName = input[1];
                        string machineName = input[2];
                        result = this.machinesManager.EngageMachine(pilotName, machineName);
                    }
                    else if (input[0] == "Attack")
                    {
                        string attacker = input[1];
                        string defender = input[2];
                        result = this.machinesManager.AttackMachines(attacker, defender);
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }
        }
    }
}
