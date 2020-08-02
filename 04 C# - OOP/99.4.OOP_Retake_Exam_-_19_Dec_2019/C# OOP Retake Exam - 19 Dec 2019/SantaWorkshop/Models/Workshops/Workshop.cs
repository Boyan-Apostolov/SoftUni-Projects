using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (!present.IsDone() && (dwarf.Energy > 0 && dwarf.Instruments.Any(a => a.Power > 0)))
            {
                dwarf.Work();
                present.GetCrafted();
                var instrument = dwarf.Instruments.First(i => i.Power > 0);
                instrument.Use();
            }

        }
    }
}
