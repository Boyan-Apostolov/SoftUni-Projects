using System.Collections.Generic;
using System.Linq;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;
        private List<Fighter> fighters;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.fighters = new List<Fighter>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == name);

            IPilot usablePilot = null;

            if (pilot == null)
            {
                usablePilot = new Pilot(name);
                this.pilots.Add(usablePilot);
                return $"Pilot {name} hired";
            }
            else
            {
                return $"Pilot {name} is hired already";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);
            if (this.machines.Contains(tank))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(tank);

            return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (this.fighters.Contains(fighter))
            {
                return $"Machine {name} is manufactured already";
            }

            this.fighters.Add(fighter);
            return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null) 
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null) 
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            machine.Pilot = pilot;
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            if (attacker == null)
            {
                return $"Machine {attacker.Name} could not be found";
            }
            if (attacker.HealthPoints <= 0)
            {
                return $"Dead machine {attacker.Name} cannot attack or be attacked";
            }
            var deffender = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);
            if (deffender == null)
            {
                return $"Machine {deffender.Name} could not be found";
            }
            if (deffender.HealthPoints <= 0)
            {
                return $"Dead machine {deffender.Name} cannot attack or be attacked";
            }

            attacker.Attack(deffender);

            return
                $"Machine {deffender.Name} was attacked by machine {attacker.Name} - current health: {deffender.HealthPoints}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);
            
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = this.fighters.FirstOrDefault(f => f.Name == fighterName);

            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            fighter.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)this.machines.FirstOrDefault(m=>m.Name == tankName);

            if (tank==null)
            {
                return $"Machine {tankName} could not be found";
            }

            tank.ToggleDefenceMode();

            return $"Tank {tankName} toggled defense mode"; ;
        }
    }
}