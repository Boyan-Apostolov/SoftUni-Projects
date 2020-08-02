using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private ICollection<IDwarf> dwarves;
        private ICollection<IPresent> presents;
        private IWorkshop workshop;
        private int craftedPresents = 0;

        public Controller()
        {
            this.dwarves = new List<IDwarf>();
            this.presents = new List<IPresent>();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarves.Add(dwarf);
            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);

        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarves.FirstOrDefault(d => d.Name == dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.Instruments.Add(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var readyDwarves = this.dwarves.Where(d => d.Energy >= 50);

            IPresent present = this.presents.FirstOrDefault(p => p.Name == presentName);

            if (!readyDwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            foreach (IDwarf dwafr in readyDwarves)
            {
                workshop.Craft(present, dwafr);
                if (dwafr.Energy == 0)
                {
                    this.dwarves.Remove(dwafr);
                    if (present.IsDone())
                    {
                        break;
                    }
                    
                }
                if (present.IsDone())
                {
                    break;
                }
            }

            string isDone = "";

            if (present.IsDone())
            {
                this.craftedPresents++;
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }

            return string.Format(OutputMessages.PresentIsNotDone, presentName);


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{craftedPresents} are done!");
            sb.AppendLine($"Dwarfs info:");
            foreach (var dwarf in this.dwarves)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {dwarf.Instruments.Count(c=>c.IsBroken() == false)} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
