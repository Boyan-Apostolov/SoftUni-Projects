using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.IO.Contracts;
using P07_MilitaryElite.Models;

namespace P07_MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader,IWriter writer) : this()
        {
            this.writer = writer;
            this.reader = reader;
        }
       
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split().ToArray();

                string solierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                ISoldier soldier = null;

                if (solierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id,firstName,lastName,salary);
                }
                else if (solierType == "LiutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new LieutenantGeneral(id,firstName,lastName,salary);
                    foreach (var pid in cmdArgs.Skip(5))
                    {
                      //  ISoldier privateToAdd = this.soldiers.First(s => s.Id = int.Parse(pid));
                        
                    }
                }
                else if (solierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        IEngineer engineer = new Engineer(id,firstName,lastName,salary,corps);
                        string[] repairArgs = cmdArgs.Skip(6).ToArray();
                        for (int i = 0; i < repairArgs.Length; i+=2)
                        {
                            string partName = repairArgs[i];
                            int hoursWorked = int.Parse(repairArgs[i + 1]);
                            IRepair repair = new Repair(partName,hoursWorked);
                            engineer.AddRepair(repair);
                            soldier = engineer;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        continue;;
                    }
                }
                else if (solierType == "Commando")
                {
                    try
                    {
                        decimal salary = decimal.Parse(cmdArgs[4]);
                        string corps = cmdArgs[5];
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        try
                        {
                            string[] missionArgs = cmdArgs.Skip(6).ToArray();
                            for (int i = 0; i < missionArgs.Length; i+=2)
                            {
                                string missionComeName = missionArgs[i];
                                string missionState = missionArgs[i + 1];
                                IMission mission=new Mission(missionComeName,missionState);
                                commando.AddMIssion(mission);
                                soldier = commando;
                            }
                        }
                        catch (ArgumentException e)
                        {
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else if (solierType == "Spy")
                {
                    int coddNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, coddNumber);
                }


                if (soldier != null)
                {
                   this.soldiers.Add(soldier); 
                }
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
