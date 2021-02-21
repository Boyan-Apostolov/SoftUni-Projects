namespace SantaWorkshop.Models.Workshops
{
    using System.Linq;

    using Dwarfs.Contracts;
    using Presents.Contracts;
    using Workshops.Contracts;

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
