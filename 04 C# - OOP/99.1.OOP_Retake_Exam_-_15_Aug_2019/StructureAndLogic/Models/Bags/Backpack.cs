using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new Collection<string>();
        }

        public ICollection<string> Items { get; }
    }
}
